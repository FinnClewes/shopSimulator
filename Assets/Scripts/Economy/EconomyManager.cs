using System;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public int Money { get; private set; }   // starts at 0

    public event Action<int> OnMoneyChanged;

    void Start() => OnMoneyChanged?.Invoke(Money);   // so the HUD shows 0 at the start

    public void Earn(int amount)
    {
        Money += amount;
        OnMoneyChanged?.Invoke(Money);
    }

    public bool Spend(int amount)
    {
        if (amount > Money) return false;    // can't afford it
        Money -= amount;
        OnMoneyChanged?.Invoke(Money);
        return true;
    }
}