using Unity.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int currentDay = 0;
    int weekNumber = 1;
    [SerializeField] Camera tillCamera;
    [SerializeField] Camera topDownCamera;
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
        // change camera to top-down
        tillCamera.enabled = false;
        topDownCamera.enabled = true;
    }

    public void StartDay() 
    {
        phase = GamePhase.Day;
        currentDay++;
        // change to till camera
        tillCamera.enabled = true;
        topDownCamera.enabled = false;
    }

    public void EndDay() 
    {
        // day summary screen
        //  - money earned/lost
        //  - customers served
        //  - card progress (later)
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
