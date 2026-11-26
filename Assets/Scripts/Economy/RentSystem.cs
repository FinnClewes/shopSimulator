using UnityEngine;

public class RentSystem : MonoBehaviour
{
    public int BaseRent { get; set; } = 130;
    public int WeeklyIncrease { get; set; } = 30;

    public int GetRentDue(int week) => BaseRent + WeeklyIncrease * (week - 1);
}
