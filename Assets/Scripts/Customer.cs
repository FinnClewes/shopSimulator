using UnityEngine;
using UnityEngine.AI;

public enum CustomerState { WalkToQueue, Waiting, BeingServed, Leaving }

public class Customer : MonoBehaviour
{
    NavMeshAgent agent;
    CustomerSpawner spawner;
    TillQueue queue;

    public CustomerState State { get; private set; }

    public void Init(CustomerSpawner s, TillQueue q)
    {
        spawner = s;
        queue = q;
        agent = GetComponent<NavMeshAgent>();
        State = CustomerState.WalkToQueue;
        queue.Enqueue(this);          // joins the line straight away
    }

    // Called by TillQueue to say where to stand
    public void MoveTo(Vector3 position)
    {
        if (State == CustomerState.Leaving || State == CustomerState.BeingServed) return;
        State = CustomerState.WalkToQueue;
        agent.SetDestination(position);
    }

    void Update()
    {
        if (agent == null || agent.pathPending) return;

        bool arrived = agent.remainingDistance <= agent.stoppingDistance + 0.1f;
        if (!arrived) return;

        if (State == CustomerState.WalkToQueue)
            State = CustomerState.Waiting;
        else if (State == CustomerState.Leaving)
            Leave();
    }

    // Till calls these two
    public void Serve() => State = CustomerState.BeingServed;
    public void FinishServed()
    {
        queue.Remove(this);           // everyone behind steps forward
        State = CustomerState.Leaving;
        agent.SetDestination(spawner.exitPoint.position);
    }

    public void Leave()
    {
        spawner.OnCustomerLeft();
        Destroy(gameObject);
    }
}