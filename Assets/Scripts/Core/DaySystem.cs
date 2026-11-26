using UnityEngine;
using System;

public class DaySystem : MonoBehaviour
{
    [SerializeField] float dayLength = 180f;          // 3 minutes
    [SerializeField] CustomerSpawner spawner;
    [SerializeField] HagglingMinigame haggle;

    public float TimeRemaining { get; private set; }
    public bool IsRunning { get; private set; }

    public event Action OnDayEnded;

    public void StartDay(int customerCount)
    {
        TimeRemaining = dayLength;
        IsRunning = true;
        spawner.StartDay(customerCount, dayLength);
    }

    void Update()
    {
        if (!IsRunning) return;

        TimeRemaining = Mathf.Max(0f, TimeRemaining - Time.deltaTime);

        bool timeUp = TimeRemaining <= 0f;
        bool everyoneDone = spawner.IsDayComplete;

        // never cut off a sale in progress: wait until the haggle closes
        if ((timeUp || everyoneDone) && !haggle.IsOpen)
            EndDay();
    }

    void EndDay()
    {
        IsRunning = false;
        spawner.StopDay();               // customers still in the shop leave
        OnDayEnded?.Invoke();
    }
}
