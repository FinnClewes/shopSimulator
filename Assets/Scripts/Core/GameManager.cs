using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] CustomerSpawner spawner;
    [SerializeField] EconomyManager economy;
    [SerializeField] GameObject summaryPanel;
    [SerializeField] TMP_Text summaryText;

    [SerializeField] GameObject nextDayButton;
    [SerializeField] int daysPerWeek = 7;

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
        weekNumber = (currentDay - 1) / daysPerWeek + 1;
        summaryPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        spawner.StartDay(CustomerSpawner.GetCustomerCount(weekNumber));
    }

    public void EndDay()
    {
        phase = GamePhase.Night;
        string text = $"Day {currentDay} complete\nMoney: €{economy.Money}\nCustomers lost: {spawner.CustomersLost}";
        int rent = economy.Rent.GetRentDue(weekNumber);

        if (currentDay % daysPerWeek == 0)                 // last day of the week: rent is due now
        {
            if (!economy.PayRent(weekNumber))
            {
                GameOver($"You couldn't pay the €{rent} rent");
                return;
            }
            text += $"\nRent paid: €{rent}";
        }
        else
        {
            int daysLeft = daysPerWeek - (currentDay % daysPerWeek);
            text += $"\nRent of €{rent} due in {daysLeft} day(s)";
        }

        summaryText.text = text;
        nextDayButton.SetActive(true);
        ShowSummary();
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

    public void GameOver(string reason)
    {
        phase = GamePhase.GameOver;
        summaryText.text = $"GAME OVER\n{reason}\nDays survived: {currentDay}";
        nextDayButton.SetActive(false);
        ShowSummary();
    }

    void ShowSummary()
    {
        summaryPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
