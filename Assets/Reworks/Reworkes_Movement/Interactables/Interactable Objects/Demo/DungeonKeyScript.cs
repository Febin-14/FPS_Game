using UnityEngine;

public class DungeonKeyScript : MonoBehaviour, IInteractable
{
    [SerializeField] private string dungeonKeyInteractPrompt;
    [SerializeField] private ItemSO dungeonKeyItemData;
    public string GetInteractionPrompt()
    {
        return dungeonKeyInteractPrompt;
    }

    public void Interact()
    {
        bool added = InventoryManager.Instance.Additem(dungeonKeyItemData);
        if (added)
        {
            Destroy(gameObject);
        }
    }
}
