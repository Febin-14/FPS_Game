using UnityEngine;
using UnityEngine.EventSystems;

public class InspectDragHandler : MonoBehaviour,IDragHandler
{
    [SerializeField] private float rotationSpeed = 5f;
    public void OnDrag(PointerEventData eventData)
    {
        if (InspectManager.Instance != null && InspectManager.Instance.CurrentObject != null)
        {
            InspectManager.Instance.CurrentObject.transform.Rotate(Vector3.up, -eventData.delta.x * rotationSpeed,Space.World);
            InspectManager.Instance.CurrentObject.transform.Rotate(Vector3.forward, eventData.delta.y * rotationSpeed,Space.Self);
        }
    }

}
