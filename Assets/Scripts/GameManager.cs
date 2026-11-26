using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CustomerSpawner spawner;

    int currentDay = 0;
    int weekNumber = 1;
    GamePhase phase;

    public enum GamePhase
    {
        Day,
        Night,
        WeekSummary,
        GameOver
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartDay();   // temporary: starts day 1 on Play
    }

    void Update()
    {
        if (phase == GamePhase.Day && spawner.IsDayComplete)
            EndDay();
    }

    public void StartDay()
    {
        phase = GamePhase.Day;
        currentDay++;
        spawner.StartDay(CustomerSpawner.GetCustomerCount(weekNumber));
    }

    public void EndDay()
    {
        phase = GamePhase.Night;   // stops Update from calling EndDay() every frame
        Debug.Log($"Day {currentDay} complete");
        // day summary screen
        //  - money earned/lost
        //  - customers served
        //  - shop screen button (triggers night)
        //      - otherwise next day button (skip night)
    }

    public void StartNight()
    {
        phase = GamePhase.Night;
        // open night shop
    }

    public void EndWeek()
    {
        phase = GamePhase.WeekSummary;
        weekNumber++;
    }

    public void GameOver()
    {
        phase = GamePhase.GameOver;
    }
}
