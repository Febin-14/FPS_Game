using UnityEngine;

public class DemoKeyScript : MonoBehaviour, IInteractable
{
    [SerializeField] private string demoKeyInterectionKeyPrompt;
    [SerializeField] private ItemSO demoKeyItemData;

    public string GetInteractionPrompt()
    {
        return demoKeyInterectionKeyPrompt;
    }

    public void Interact()
    {
        bool added = InventoryManager.Instance.Additem(demoKeyItemData);
        if(added)
        {
            Destroy(gameObject);
        }
    }
}
