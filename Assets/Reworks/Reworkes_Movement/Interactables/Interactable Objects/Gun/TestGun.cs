using UnityEngine;

public class TestGun : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactionPrompt = "Press E to interact.";
    [SerializeField] private ItemSO itemData;
    public void Interact()
    {
        bool added = InventoryManager.Instance.Additem(itemData);
        if (added)
        {
            Destroy(gameObject);
        }
    }
    public string GetInteractionPrompt()
    {
        return interactionPrompt;
    }
}
