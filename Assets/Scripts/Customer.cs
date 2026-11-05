using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    NavMeshAgent agent;
    CustomerSpawner spawner;

    public void Init(CustomerSpawner s)
    {
        spawner = s;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(s.exitPoint.position);   // temporary: just walk out
    }

    void Update()
    {
        if (agent != null && !agent.pathPending && agent.remainingDistance < 0.5f)
            Leave();
    }

    public void Leave()
    {
        spawner.OnCustomerLeft();
        Destroy(gameObject);
    }
}