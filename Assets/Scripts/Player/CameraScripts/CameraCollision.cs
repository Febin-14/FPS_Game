using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform player;
    public float distance = 0.2f;
    public float collisionOffset = 0.05f;

    private Vector3 desiredPosition;

    void LateUpdate()
    {
        Vector3 origin = player.position;
        Vector3 direction = transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit, distance))
        {
            transform.position = hit.point - direction * collisionOffset;
        }
        else
        {
            transform.position = origin + direction * distance;
        }
    }

}
