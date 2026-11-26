using TMPro;
using UnityEngine;

public class CustomersDisplay : MonoBehaviour
{
    [SerializeField] CustomerSpawner spawner;
    TMP_Text label;

    void Awake() => label = GetComponent<TMP_Text>();

    void OnEnable()
    {
        spawner.OnCountChanged += UpdateLabel;
        UpdateLabel();
    }

    void OnDisable() => spawner.OnCountChanged -= UpdateLabel;

    void UpdateLabel() => label.text = $"Customers left: {spawner.CustomersLeft}";
}
