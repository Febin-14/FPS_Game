using UnityEngine;

public class TestKeyScript : MonoBehaviour, IInteractable
{
    [SerializeField] private string rustyKeyInteractionPrompt;
    [SerializeField] private ItemSO rustyKeyItemData;

    public string GetInteractionPrompt()
    {
        return rustyKeyInteractionPrompt;
    }

    public void Interact()
    {
        bool added = InventoryManager.Instance.Additem(rustyKeyItemData);
        if(added)
        {
            Destroy(gameObject);
        }
    }
}
