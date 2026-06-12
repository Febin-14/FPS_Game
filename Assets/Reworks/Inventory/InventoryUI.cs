using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private InputManager inputManager;
    

    private bool inventoryOpen;

    private void Update()
    {
        if (inputManager.InventoryInput)
        {
            ToggleInventory();
            inputManager.ConsumeInventory();
            if (inventoryOpen)
            {
                Debug.Log(GameManager.Instance);
                GameManager.Instance.SetState(GameState.Inventory);
            }
            else
            {
                GameManager.Instance.SetState(GameState.Playing);
            }
        }
    }

    private void ToggleInventory()
    {
        inventoryOpen = !inventoryOpen;
        Debug.Log("Inventory State" + inventoryOpen);
        inventoryPanel.SetActive(inventoryOpen);
    }
}