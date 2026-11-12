using UnityEngine;

public class TillInteratable : MonoBehaviour, IInteractable
{
    [SerializeField] TillQueue queue;
    [SerializeField] EconomyManager economy;

    [SerializeField] HagglingMinigame haggle;

    bool CanServe => !haggle.IsOpen
              && queue.Front != null
              && queue.Front.State == CustomerState.Waiting;

    public string Prompt => CanServe ? "serve customer" : "no customers waiting";

    public void Interact()
    {
        if (!CanServe) return;

        var customer = queue.Front;
        customer.Serve();

        haggle.Begin(multiplier =>
        {
            int price = Mathf.RoundToInt(5 * multiplier);   // 5 = baseline for now
            economy.Earn(price);
            Debug.Log($"Sale made for €{price}");
            customer.FinishServed();
        });
    }
}
