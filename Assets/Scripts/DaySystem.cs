using UnityEngine;

public class DaySystem : MonoBehaviour
{
    int dayNumber;
    bool isComplete = false;

    void GetCustomerCount(int customer)
    {
        return;
    }

    void IsDayComplete(int customer, bool isComplete)
    {
        if (customer == 0)
        {
            isComplete = true;
        }
        else
        {
            isComplete = false;
        }
    }
}
