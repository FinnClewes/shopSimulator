using UnityEngine;

public class TillInteractable : MonoBehaviour, IInteractable
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
            float patience = customer.Patience.GetMultiplier();
            int price = Mathf.RoundToInt(5 * multiplier * patience);   // 5 = baseline for now
            economy.Earn(price);
            Debug.Log($"Sale: 5 x haggle {multiplier:0.00} x patience {patience:0.00} = €{price}");
            customer.FinishServed();
        });
    }
}
