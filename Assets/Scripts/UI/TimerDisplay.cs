using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] DaySystem daySystem;
    TMP_Text label;

    private void Awake() => label = GetComponent<TMP_Text>();

    private void Update()
    {
        int t = Mathf.CeilToInt(daySystem.TimeRemaining);
        label.text = $"{t / 60}:{t % 60:00}";
    }

}
