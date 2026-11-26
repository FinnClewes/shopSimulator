using System.Threading;
using UnityEngine;
using static Unity.Entities.Content.RemoteContentLocation;

public class Item : MonoBehaviour, IInteractable
{
    // public DonationType type; //need to add donation types
    public int baselinePrice = 5;
    public bool isClean;
    public float cleaningScore = 1f;

    Rigidbody rb;
    Collider col;

    public string Prompt => "pick up";

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    public void Interact()
    {
        if (!Carrier.Instance.HasItem)
            Carrier.Instance.PickUp(this);
    }

    public void SetHeld(bool held)
    {
        rb.isKinematic = held;
        col.enabled = !held;   // so the held item doesn't block your raycast
    }
}