using System.Collections.Generic;
using UnityEngine;

public class ShelfSlot : MonoBehaviour, IInteractable
{
    public static readonly List<ShelfSlot> All = new();

    Item stored;
    bool reserved;      // a customer is on their way to take it

    public bool HasStock => stored != null && !reserved;

    public string Prompt =>
        reserved ? "a customer is looking at this"
        : stored == null ? "place item" : "take item";

    void OnEnable() => All.Add(this);
    void OnDisable() => All.Remove(this);

    public bool TryReserve()
    {
        if (!HasStock) return false;
        reserved = true;
        return true;
    }

    // Customers call this when they arrive
    public Item TakeForCustomer()
    {
        var item = stored;
        stored = null;
        reserved = false;
        return item;
    }

    public void Interact()
    {
        var carrier = Carrier.Instance;

        if (stored == null && carrier.HasItem)
        {
            stored = carrier.TakeHeld();
            stored.transform.SetPositionAndRotation(transform.position, transform.rotation);
            // stays kinematic with its collider off while stored
        }
        else if (stored != null && !reserved && !carrier.HasItem)
        {
            carrier.PickUp(stored);
            stored = null;
        }
    }
}
