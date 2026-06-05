using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float groundForce = -2f;
    [SerializeField] private float gravity = -9.81f;
    
    private float _verticalVelocity;
    private CharacterController _characterController;
    private InputManager _inputManager;
    private bool isGrounded;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleGrounding();
        HandleMovement();
       HandleJump();


        


    }
    private bool IsGrounded()
    { 
        return Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
    }
    private void OnDrawGizmosSelected()
    {
        if (_groundCheck == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(
            _groundCheck.position,
            _groundDistance);
    }
    private void OnJump()
    {
        if (isGrounded)
        {
            _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            _inputManager.ConsumeJump();// Reset jump input after processing


        }
    }
   
    private float GetSpeed()
    {
        return _inputManager.SprintInput ? sprintSpeed : moveSpeed; 
    }
    private void HandleMovement()
    {
        
        _verticalVelocity += gravity * Time.deltaTime;
        Vector3 moveDirection = transform.forward * _inputManager.MoveInput.y + transform.right * _inputManager.MoveInput.x;
        moveDirection *= GetSpeed();

        moveDirection.y = _verticalVelocity;


        _characterController.Move(moveDirection * Time.deltaTime);
    }
    private void HandleJump()
    {
        if (_inputManager.JumpInput)
        {
            OnJump();
        }
    }
    private void HandleGrounding()
    {
        isGrounded = IsGrounded();
        if (isGrounded && _verticalVelocity < 0)
        {
            _verticalVelocity = groundForce; // Small negative value to keep the player grounded
        }
    }

}
