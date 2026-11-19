using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] EconomyManager economy;
    TMP_Text label;

    void Awake() => label = GetComponent<TMP_Text>();

    void OnEnable() => economy.OnMoneyChanged += UpdateLabel;
    void OnDisable() => economy.OnMoneyChanged -= UpdateLabel;

    void UpdateLabel(int money) => label.text = $"€{money}";
}