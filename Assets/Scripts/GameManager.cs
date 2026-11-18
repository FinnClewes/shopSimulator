using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CustomerSpawner spawner;
    [SerializeField] EconomyManager economy;
    [SerializeField] GameObject summaryPanel;
    [SerializeField] TMP_Text summaryText;

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
        weekNumber = (currentDay - 1) / 7 + 1;      // days 1-7 = week 1, 8-14 = week 2, ...
        summaryPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        spawner.StartDay(CustomerSpawner.GetCustomerCount(weekNumber));
    }

    public void EndDay()
    {
        phase = GamePhase.Night;
        summaryText.text = $"Day {currentDay} complete\nMoney: €{economy.Money}";
        summaryPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void NextDay() => StartDay();

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
