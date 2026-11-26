using UnityEngine;

public class CleaningStation : MonoBehaviour, IInteractable
{
    [SerializeField] CleaningMinigame minigame;
    [SerializeField] int startingUses = 8;

    public int UsesRemaining { get; private set; }
    public event System.Action OnUsesChanged;

    void Awake() => UsesRemaining = startingUses;
    void Start() => OnUsesChanged?.Invoke();

    public void AddUses(int amount)            // night shop calls this
    {
        UsesRemaining += amount;
        OnUsesChanged?.Invoke();
    }

    public string Prompt
    {
        get
        {
            var carrier = Carrier.Instance;
            if (minigame.IsOpen) return "";
            if (!carrier.HasItem) return "bring an item to clean";
            if (carrier.Held.isClean) return "this item is already clean";
            if (UsesRemaining <= 0) return "no cleaning supplies left";
            return "clean item";
        }
    }

    public void Interact()
    {
        var carrier = Carrier.Instance;
        if (minigame.IsOpen || !carrier.HasItem) return;

        var item = carrier.Held;
        if (item.isClean || UsesRemaining <= 0) return;

        minigame.Begin(score =>
        {
            item.cleaningScore = score;
            item.isClean = true;
            UsesRemaining--;
            OnUsesChanged?.Invoke();
        });
    }
}
