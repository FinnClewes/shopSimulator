using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] float range = 2.5f;
    [SerializeField] LayerMask interactMask;
    [SerializeField] TMP_Text promptText;

    IInteractable current;

    void Update()
    {
        current = null;

        //Debug.DrawRay(transform.position, transform.forward * range, Color.red);

        if (Physics.Raycast(transform.position, transform.forward,
                            out RaycastHit hit, range, interactMask))
        {
           // Debug.Log("Hit: " + hit.collider.name);
            current = hit.collider.GetComponentInParent<IInteractable>();
            if (current == null)
                current = hit.collider.GetComponentInChildren<IInteractable>();

            /*Debug.Log(current == null
                ? "No IInteractable found on " + hit.collider.name
                : "Found interactable on " + hit.collider.name);*/
        }

        promptText.gameObject.SetActive(current != null);

        if (current != null)
        {
            promptText.text = $"Press E to {current.Prompt}";
            if (Keyboard.current.eKey.wasPressedThisFrame)
                current.Interact();
        }
    }
}
