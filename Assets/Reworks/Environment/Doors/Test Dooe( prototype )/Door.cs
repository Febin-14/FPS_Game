using System;
using System.Data.Common;
using UnityEngine;
public enum DoorType
{
    Steel,
    Wood
}

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string doorInteractionPrompt;
    [SerializeField] private ItemSO requiredKey;
    [SerializeField] private DoorType doorType;
    private bool isOpen;
    private Quaternion closeRotatiion;
    private Quaternion openRoatation;


    void Start()
    {
        closeRotatiion = transform.rotation;
        openRoatation = closeRotatiion * Quaternion.Euler(0, 90, 0);
    }
    void Update()
    {
        Quaternion targetRotation = isOpen ? openRoatation : closeRotatiion;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    public string GetInteractionPrompt()
    {
        return doorInteractionPrompt;
    }

    public void Interact()
    {
        if (!InventoryManager.Instance.HasItem(requiredKey))
        {
            string keyMissing = "Key is Missing";
            InventoryManager.Instance.ShowMessage(keyMissing);
            return;
        }
        if(!isOpen)
        {
            OpenTestDoor(); 
        }
        else
        {
            CloseDoor();
        }

    }
    public void OpenTestDoor()
    {
        isOpen = true;
        AudioManager.Instance.OpenDoorSound(doorType);
    }
    public void CloseDoor()
    {
        AudioManager.Instance.CloseDoorSound(doorType);
        isOpen = false;
    }

}

   

