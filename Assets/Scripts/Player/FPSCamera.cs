//using Febin.InputManagers;
//using UnityEngine;

//public class FPSCamera : MonoBehaviour
//{
//    public Transform player;
//    public InputManager inputManager;


//public float mouseSensitivity = 0.1f;

//    private float xRotation = 0f;

//    [SerializeField]private float upperLimit = -2f;
//    [SerializeField] private float lowerLimit = -60f;

//    public float distance = 0.2f;
//    public float collisionOffset = 0.05f;

//    private Vector3 origin;
//    private Vector3 direction;
//    public Transform Head;

//    private Rigidbody playerRb;

//    void Start()
//    {
//        playerRb = player.GetComponent<Rigidbody>();
        
//    }

//    void LateUpdate()
//    {
//        float mouseX = inputManager.Look.x * mouseSensitivity;
//        float mouseY = inputManager.Look.y * mouseSensitivity;

//        origin = player.position;
//        direction = transform.forward;

        

//        // Draw the ray every frame for debugging
//        Debug.DrawRay(origin, direction * distance, Color.red);

//        // Vertical camera rotation
//        xRotation -= mouseY;
//        xRotation = Mathf.Clamp(xRotation, lowerLimit, upperLimit);
//        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
//        transform.position = Head.position;

//        // Horizontal player rotation
//        playerRb.MoveRotation(playerRb.rotation * Quaternion.Euler(0f, mouseX, 0f) );

//        //RaycastHit hit;

//        //if (Physics.Raycast(origin, direction, out hit, distance))
//        //{
//        //    Debug.Log("Hit: " + hit.collider.name);

//        //    transform.position = hit.point - direction * collisionOffset;
//        //}
//        //else
//        //{
//        //    Debug.Log("No Hit");

//        //    transform.position = origin + direction * distance;
//        //}
//    }
    

//}
