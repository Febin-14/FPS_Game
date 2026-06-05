using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float maxLookUpAngle = 80f;
    [SerializeField] private float maxLookDownAngle = 60f;
    private float _xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        float mouseX =
            _inputManager.LookInput.x * mouseSensitivity;

        float mouseY =
            _inputManager.LookInput.y * mouseSensitivity;

        _xRotation -= mouseY;

        _xRotation =
            Mathf.Clamp(_xRotation, -maxLookDownAngle,maxLookUpAngle);

        transform.localRotation =
            Quaternion.Euler(_xRotation, 0f, 0f);

        player.Rotate(Vector3.up * mouseX);
    }
}