using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] Customer customerPrefab;
    [SerializeField] Transform spawnPoint;
    public Transform exitPoint;

    [SerializeField] float dayLength = 180f;
    [SerializeField] float spawnWindow = 0.8f;   // spawn within first 80% of the day

    public int customersRemaining { get; private set; }
    public int activeCustomers { get; private set; }

    readonly Queue<float> spawnTimes = new();
    float dayTimer;
    bool running;

    // Tier 1: base 5, +1 per week, cap 14
    public static int GetCustomerCount(int week, int tierBase = 5)
        => Mathf.Min(tierBase + (week - 1), 14);

    public void StartDay(int count)
    {
        spawnTimes.Clear();
        customersRemaining = count;
        activeCustomers = 0;
        dayTimer = 0f;

        float window = dayLength * spawnWindow;
        float gap = window / count;
        for (int i = 0; i < count; i++)
        {
            float t = i * gap + Random.Range(0f, gap * 0.5f);
            spawnTimes.Enqueue(t);          // FIFO: earliest time spawns first
        }
        running = true;
    }

    void Update()
    {
        if (!running) return;
        dayTimer += Time.deltaTime;

        while (spawnTimes.Count > 0 && dayTimer >= spawnTimes.Peek())
        {
            spawnTimes.Dequeue();
            SpawnCustomer();
        }
    }

    void SpawnCustomer()
    {
        var c = Instantiate(customerPrefab, spawnPoint.position, spawnPoint.rotation);
        c.Init(this);
        customersRemaining--;
        activeCustomers++;
    }

    public void OnCustomerLeft() => activeCustomers--;

    public bool IsDayComplete => customersRemaining == 0 && activeCustomers == 0;
}