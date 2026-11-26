using UnityEngine;
using System.Collections.Generic;

public class TillQueue : MonoBehaviour
{
    [SerializeField] Transform[] spots;  // 0 is at till

    readonly List<Customer> line = new();

    public int Count => line.Count;
    public Customer Front => line.Count > 0 ? line[0] : null;

    public void Enqueue(Customer c)
    {
        line.Add(c);
        Reposition();
    }

    public void Remove(Customer c)
    {
        if (line.Remove(c)) Reposition();
    }

    void Reposition()
    {
        for (int i = 0; i < line.Count; i++)
        {
            // if there are more customers than spots, extras share the last spot
            int spot = Mathf.Min(i, spots.Length - 1);
            line[i].MoveTo(spots[spot].position);
        }
    }
}
