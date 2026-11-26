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
            var item = customer.Carrying;
            int baseline = item != null ? item.baselinePrice : 5;
            float cleaning = item != null ? item.cleaningScore : 1f;

            int price = Mathf.RoundToInt(baseline * multiplier * patience);
            economy.Earn(price);
            Debug.Log($"Sale: {baseline} x clean {cleaning:0.0} x haggle {multiplier:0.00} x patience {patience:0.00} = €{price}");
            customer.FinishServed();
        });
    }
}
