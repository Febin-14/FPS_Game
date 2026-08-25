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
            if(GameManager.Instance.currentState == GameState.Playing)
            {
                ToggleInventory();
            }
            else if(GameManager.Instance.currentState == GameState.Inventory)
            {
                ToggleInventory();  
            }

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
        AudioManager.Instance.OpenInventorySound();
        inventoryPanel.SetActive(inventoryOpen);
    }
}