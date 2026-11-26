using UnityEngine;
using TMPro;

public class CleaningUsesDisplay : MonoBehaviour
{
    [SerializeField] CleaningStation station;
    TMP_Text label;

    void Awake() => label = GetComponent<TMP_Text>();
    void OnEnable() { station.OnUsesChanged += Refresh; Refresh(); }
    void OnDisable() => station.OnUsesChanged -= Refresh;

    void Refresh() => label.text = $"Cleaning supplies: {station.UsesRemaining}";
}
