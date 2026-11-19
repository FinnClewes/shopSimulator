using UnityEngine;

public class ShelfSlot : MonoBehaviour, IInteractable
{
    Item stored;

    public string Prompt => stored == null ? "place item" : "take item";

    public void Interact()
    {
        var carrier = Carrier.Instance;

        if (stored == null && carrier.HasItem)
        {
            stored = carrier.TakeHeld();
            stored.transform.SetPositionAndRotation(transform.position, transform.rotation);
            // leave it kinematic with its collider off while stored
        }
        else if (stored != null && !carrier.HasItem)
        {
            carrier.PickUp(stored);
            stored = null;
        }
    }
}
