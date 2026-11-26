using UnityEngine;
using UnityEngine.InputSystem;

public class Carrier : MonoBehaviour
{
    public static Carrier Instance { get; private set; }

    [SerializeField] Transform holdPoint;
    [SerializeField] float dropForce = 2f;

    public Item Held { get; private set; }
    public bool HasItem => Held != null;

    void Awake() => Instance = this;

    void Update()
    {
        if (HasItem && Keyboard.current.qKey.wasPressedThisFrame)
            Drop();
    }

    public void PickUp(Item item)
    {
        Held = item;
        item.SetHeld(true);
        item.transform.SetParent(holdPoint);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
    }

    public void Drop()
    {
        var item = Held;
        Held = null;
        item.transform.SetParent(null);
        item.SetHeld(false);
        item.GetComponent<Rigidbody>().AddForce(transform.forward * dropForce, ForceMode.VelocityChange);
    }

    // Used by shelves, till, cleaning station
    public Item TakeHeld()
    {
        var item = Held;
        Held = null;
        item.transform.SetParent(null);
        return item;
    }
}
