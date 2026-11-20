using UnityEngine;

public class PatienceSystem : MonoBehaviour
{
    public const float Max = 1.5f;

    public float Lowerbound { get; set; } = 0.5f;   // raised by plants later
    public float HoldTime { get; set; } = 0f;       // statue holds 1.5x for 4 s later
    public float DecayRate { get; set; } = 0.025f;  // multiplier lost per second       // gone in 40 secs

    float value = Max;
    float heldfor;

    public float GetMultiplier() => value;

    public bool IsOutOfPatience => value <= Lowerbound + 0.0001f;

    public void Tick(float deltaTime)
    {
        if (heldfor < HoldTime) 
        {
            heldfor += deltaTime;
            return;
        }
        value = Mathf.Max(Lowerbound, value - DecayRate * deltaTime);
    }
}
