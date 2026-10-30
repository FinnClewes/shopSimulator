using UnityEngine;

public class GameManager : MonoBehaviour
{
    int currentDay;
    int weekNumber;
    GamePhase phase;

    public enum GamePhase
    {
        Morning,
        Day,
        Night,
        WeekSummary,
        GameOver
    }


    public void StartMorning() 
    {
        phase = GamePhase.Morning;
    }

    public void StartDay() 
    {
        phase = GamePhase.Day;
    }

    public void EndDay() { }

    public void StartNight() 
    {
        phase = GamePhase.Night;
    }

    public void EndWeek() { }

    public void GameOver() { }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
