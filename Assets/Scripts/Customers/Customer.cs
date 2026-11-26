using UnityEngine;
using UnityEngine.AI;

public enum CustomerState { WalkToShelf, Browsing, WalkToQueue, Waiting, BeingServed, Leaving }

public class Customer : MonoBehaviour
{
    NavMeshAgent agent;
    CustomerSpawner spawner;
    TillQueue queue;
    Renderer rend;
    ShelfSlot targetSlot;
    float browseTimer;

    [SerializeField] float patienceDecayRate = 0.025f;
    [SerializeField] float browseTime = 1.5f;

    public PatienceSystem Patience {  get; private set; } = new PatienceSystem();

    public CustomerState State { get; private set; }

    public Item Carrying { get; private set; }

    public void Init(CustomerSpawner s, TillQueue q)
    {
        spawner = s;
        queue = q;
        agent = GetComponent<NavMeshAgent>();
        rend = GetComponentInChildren<Renderer>();
        Patience.DecayRate = patienceDecayRate;
        ChooseShelf();
    }

    void WalkTo(Vector3 target)
    {
        // snap to the nearest walkable point, because shelf slots may sit inside furniture
        if (NavMesh.SamplePosition(target, out var hit, 3f, NavMesh.AllAreas))
            target = hit.position;
        agent.SetDestination(target);
    }

    // Called by TillQueue to say where to stand
    public void MoveTo(Vector3 position)
    {
        if (State == CustomerState.Leaving || State == CustomerState.BeingServed) return;
        State = CustomerState.WalkToQueue;
        agent.SetDestination(position);
    }

    void ChooseShelf()
    {
        var options = ShelfSlot.All.FindAll(slot => slot.HasStock);
        if (options.Count == 0)
        {
            LeaveEmptyHanded();                       // nothing to buy
            return;
        }

        targetSlot = options[Random.Range(0, options.Count)];
        targetSlot.TryReserve();
        State = CustomerState.WalkToShelf;
        WalkTo(targetSlot.transform.position);
    }

    void TakeItemAndQueue()
    {
        Carrying = targetSlot.TakeForCustomer();
        targetSlot = null;

        if (Carrying != null)
        {
            Carrying.transform.SetParent(transform);
            Carrying.transform.localPosition = new Vector3(0f, 1.3f, 0f);   // floats above their head
        }

        State = CustomerState.WalkToQueue;
        queue.Enqueue(this);                          // TillQueue sends them to their spot
    }

    void LeaveEmptyHanded()
    {
        State = CustomerState.Leaving;
        WalkTo(spawner.exitPoint.position);
    }


    void Update()
    {
        if (agent == null) return;

        if (State == CustomerState.WalkToQueue || State == CustomerState.Waiting)
        {
            Patience.Tick(Time.deltaTime);

            if (rend != null)
                rend.material.color = Color.Lerp(Color.red, Color.green, Patience.GetMultiplier() - 0.5f);

            if (Patience.IsOutOfPatience)
            {
                LeaveAngry();
                return;
            }
        }

        if (State == CustomerState.Browsing)
        {
            browseTimer -= Time.deltaTime;
            if (browseTimer <= 0f) TakeItemAndQueue();
            return;
        }

        if (agent.pathPending) return;
        bool arrived = agent.remainingDistance <= agent.stoppingDistance + 0.1f;
        if (!arrived) return;

        switch (State)
        {
            case CustomerState.WalkToShelf:
                State = CustomerState.Browsing;
                browseTimer = browseTime;
                break;
            case CustomerState.WalkToQueue:
                State = CustomerState.Waiting;
                break;
            case CustomerState.Leaving:
                Leave();
                break;
        }
    }

    // Till calls these two
    public void Serve() => State = CustomerState.BeingServed;
    public void FinishServed()
    {
        queue.Remove(this);
        if (Carrying != null) Destroy(Carrying.gameObject);   // bought: the item is gone
        State = CustomerState.Leaving;
        WalkTo(spawner.exitPoint.position);
    }

    public void Leave()
    {
        spawner.OnCustomerLeft();
        Destroy(gameObject);
    }

    void LeaveAngry()
    {
        Debug.Log($"{name} ran out of patience and left");
        spawner.RegisterLost();
        queue.Remove(this);

        if (Carrying != null)       // drops the item so you can re-shelve it
        {
            Carrying.transform.SetParent(null);
            Carrying.SetHeld(false);
            Carrying = null;
        }

        State = CustomerState.Leaving;
        agent.SetDestination(spawner.exitPoint.position);
    }

    public void Dismiss()
    {
        queue.Remove(this);
        if (targetSlot != null) targetSlot.CancelReservation();   // slot isn't locked

        if (Carrying != null)
        {
            Carrying.transform.SetParent(null);
            Carrying.SetHeld(false);
            Carrying = null;
        }
        Destroy(gameObject);
    }
}