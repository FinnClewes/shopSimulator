using UnityEngine;

public class TillInteratable : MonoBehaviour, IInteractable
{
    [SerializeField] TillQueue queue;

    bool CanServe => queue.Front != null && queue.Front.State == CustomerState.Waiting;

    public string Prompt => CanServe ? "serve customer" : "no customers waiting";

    public void Interact()
    {
        if (!CanServe) return;

        var customer = queue.Front;
        customer.Serve();

        // TODO: haggling minigame goes here, then pay money on finish
        Debug.Log("Sale made");

        customer.FinishServed();
    }
}
