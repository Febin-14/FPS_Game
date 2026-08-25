using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions _inputActions;
    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }

    public bool ShootInput {get; set;}
    public bool JumpInput { get; set; }
    public bool SprintInput { get; set; }
    public bool InteractInput { get; set; }
    public bool InventoryInput { get; set; }

    public bool ReloadInput { get; set; }

    private void Awake()
    {
         _inputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
    
        if(_inputActions != null)
        {
            _inputActions.Enable();
            _inputActions.Player.Move.performed += ctx =>
            {
                MoveInput = ctx.ReadValue<Vector2>();
                //Debug.Log("Performed: " + MoveInput);
            };

            _inputActions.Player.Move.canceled += ctx =>
            {
                MoveInput = Vector2.zero;
                //Debug.Log("Canceled");
            };
            _inputActions.Player.Look.performed += ctx =>
            {
                LookInput = ctx.ReadValue<Vector2>();
                //Debug.Log("Performed: " + LookInput);
            };
            _inputActions.Player.Look.canceled += ctx =>
            {
                LookInput = Vector2.zero;
                //Debug.Log("Canceled");
            };
            _inputActions.Player.Jump.performed += ctx =>
            {
                JumpInput = true;
                //Debug.Log("Performed: Jump");
            };
            _inputActions.Player.Jump.canceled += ctx =>
            {
                JumpInput = false;
                //Debug.Log("Canceled: Jump");
            };
            _inputActions.Player.Sprint.performed += ctx =>
            {
                SprintInput = true;
                //Debug.Log("Performed: Sprint");
            };
            _inputActions.Player.Sprint.canceled += ctx =>
            {
                SprintInput = false;
                //Debug.Log("Canceled: Sprint");
            };
            _inputActions.Player.Interact.performed += ctx =>
            {
                InteractInput = true;
                //Debug.Log("Performed: Interact");
            };
             _inputActions.Player.Interact.canceled += ctx =>
            {
               InteractInput = false;
            };
            _inputActions.Player.Inventory.performed += ctx =>
            {
                InventoryInput = true;
            };
            _inputActions.Player.Shoot.performed += ctx =>
            {
                ShootInput = true;
            };
            _inputActions.Player.Reload.performed += ctx =>
            {
                ReloadInput = true;
                Debug.Log("Reload Input Performed in InputManager");
            };

        }

        

    }
    private void OnDisable()
    {
        if (_inputActions != null)
        _inputActions.Disable();
    }
    private void Update()
    {
        
    }
    public void ConsumeJump()
    { JumpInput = false;
    }
    public void ConsumeShoot()
    { ShootInput = false;
    }
    public void ConsumeInteract()
    {
        InteractInput = false;
    }
    public void ConsumeReload()
    {
        ReloadInput = false;
        Debug.Log("Reload Input Consumed in InputManager");
    }
    private void OnInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InventoryInput = true;
        }
    }

    public void ConsumeInventory()
    {
        InventoryInput = false;
    }


}
