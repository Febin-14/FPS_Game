    using UnityEngine;


    public class Mouse : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    
        void Start()
        {
            Invoke(nameof(MouseLock),1f);
        }

        void MouseLock()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
