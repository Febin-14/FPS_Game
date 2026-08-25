using System;
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
    [SerializeField] private float footStepInterval = 0.4f;
    [SerializeField] private float runInterval = 0.25f;
    
    private float _verticalVelocity;
    private CharacterController _characterController;
    private InputManager _inputManager;
    private bool isGrounded;
    private bool wasGrounded;
    
    public float footStepTimer;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (GameManager.Instance.currentState != GameState.Playing)
            return;
        HandleGrounding();
        HandleMovement();
        HandleFootSteps();
        HandleJump();
        HandleShoot();
    }

    private void HandleShoot()
    {
        if(_inputManager.ShootInput)
        {
            WeaponManager.Instance.Shoot();
            _inputManager.ConsumeShoot();
        }
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
            AudioManager.Instance.PlayJumpSound();
            _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            _inputManager.ConsumeJump();// Reset jump input after processing


        }
    }
   
    private float GetSpeed()
    {
        if(!isGrounded)
            return moveSpeed; // No sprinting in the air
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
        bool isCurrentlyGrounded = IsGrounded();
        if(!wasGrounded && isCurrentlyGrounded)
        {
            AudioManager.Instance.PlayLandSound();
            
        }
        isGrounded = isCurrentlyGrounded;
        wasGrounded = isCurrentlyGrounded;

        if(!isGrounded && _verticalVelocity < 0)
        {
            _verticalVelocity = groundForce;
        }

    }
    private void HandleFootSteps()
    {
        
        bool isMoving = _inputManager.MoveInput.magnitude > 0.1f;
        float currentFootStepInterval = _inputManager.SprintInput ? runInterval : footStepInterval;
        if (!isGrounded)
        {
            footStepTimer = 0f;
            return;
        }
        if(!isMoving)
        {
            footStepTimer = footStepInterval * 0.5f;//half of footStepInterval, for faster Time.
            return;
        }
        footStepTimer += Time.deltaTime;
        if(footStepTimer >= currentFootStepInterval)
        {
            Debug.Log("Playing");
            AudioManager.Instance.PlayFootSteps();
            footStepTimer = 0;

        }
    }

}
