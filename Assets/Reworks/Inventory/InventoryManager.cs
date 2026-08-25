using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] private Slots[] slots;
    [SerializeField] private int maxSlots = 18;
    [SerializeField] private TextMeshProUGUI messageText;

    private List<ItemSO> items = new();
    private void Awake()
    {
        Instance = this;
    }
    public bool Additem(ItemSO item)
    { if(items.Count >= maxSlots)
        {
            ShowMessage("Inventory Full!");
            return false;
        }
    items.Add(item);
        AudioManager.Instance.PlayPickItem();   
        UpdateUI();
        return true;
    }
    public void RemoveItem(ItemSO item)
    {
        items.Remove(item);
    }
    public bool HasItem(ItemSO item)
    {
        return items.Contains(item);
    }
    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
                slots[i].SetItem(items[i], 1);
            else
                slots[i].ClearSlots();
        }
    }
    public void ShowMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        CancelInvoke(nameof(HideMessage));
        Invoke(nameof(HideMessage), 2f);
    }
    public void HideMessage()
    {
        messageText.gameObject.SetActive(false);
    }

}
