using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        
        {
            Debug.Log("E Key Pressed - Interact");
            Interact();



        }
    }

    void Interact()
    {
        if(Physics.Raycast(transform.position,transform.forward, out RaycastHit hitInfo, 3f))
        {
            //Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
            //if(interactable != null)
            //{
            //    interactable.OnInteract();
            //}
        }
    }

}
