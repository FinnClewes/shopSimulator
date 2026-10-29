using UnityEngine;

public class TillInteratable : MonoBehaviour, IInteractable
{
    public string Prompt => "serve customer";
    public void Interact() => Debug.Log("Till used");
}
