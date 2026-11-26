using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [SerializeField] Transform cameraRoot;          // the camera, a child of this object
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float lookSensitivity = 0.1f;  // degrees per mouse pixel
    [SerializeField] float gravity = -20f;

    CharacterController cc;
    float pitch;
    float verticalVelocity;

    void Awake() => cc = GetComponent<CharacterController>();

    void Update()
    {
        Look();
        Move();
    }

    void Look()
    {
        // no looking while a menu is open (cursor unlocked)
        if (Cursor.lockState != CursorLockMode.Locked) return;

        Vector2 delta = Mouse.current.delta.ReadValue() * lookSensitivity;
        transform.Rotate(0f, delta.x, 0f);
        pitch = Mathf.Clamp(pitch - delta.y, -85f, 85f);
        cameraRoot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void Move()
    {
        var kb = Keyboard.current;
        float x = (kb.dKey.isPressed ? 1f : 0f) - (kb.aKey.isPressed ? 1f : 0f);
        float z = (kb.wKey.isPressed ? 1f : 0f) - (kb.sKey.isPressed ? 1f : 0f);

        Vector3 move = transform.right * x + transform.forward * z;
        if (move.sqrMagnitude > 1f) move.Normalize();

        if (cc.isGrounded && verticalVelocity < 0f) verticalVelocity = -2f;
        verticalVelocity += gravity * Time.deltaTime;

        cc.Move((move * moveSpeed + Vector3.up * verticalVelocity) * Time.deltaTime);
    }
}