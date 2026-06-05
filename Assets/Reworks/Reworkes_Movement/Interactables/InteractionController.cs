using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Camera playerCamera;
    [SerializeField]private InputManager _inputManager;
    private IInteractable _currentInteractable;
    private static readonly Vector3 ViewportCenter = new Vector3(0.5f, 0.5f, 0f);
    

    private void Update()
    {
        DetectInteractable();
        if (_currentInteractable != null)
        {
            string prompt = _currentInteractable.GetInteractionPrompt();
            Debug.Log(prompt);
            if(_inputManager.InteractInput)
            {
             _currentInteractable.Interact();
            _inputManager.ConsumeInteract(); 

            }
        }
    }
    private void DetectInteractable()
    {
        Ray ray = playerCamera.ViewportPointToRay(ViewportCenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactRange, interactableLayer) )
        {
            hit.collider.TryGetComponent(out _currentInteractable);

        }
        else
        {
            _currentInteractable = null;
        }
    }

}

