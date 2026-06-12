using UnityEngine;
using TMPro;

public class InventoryInspectUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI item_name;
    [SerializeField] private TextMeshProUGUI item_Descrip;

    private ItemSO currentItem;

    public void ShowItem(ItemSO item)
    {
        currentItem = item;
        inventoryPanel.SetActive(true);
        item_name.text = item.name;
        item_Descrip.text = item.description;
    }
    public ItemSO GetCurrentItem()
    {
        return currentItem;
    }

}
