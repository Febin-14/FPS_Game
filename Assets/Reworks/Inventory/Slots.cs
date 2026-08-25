using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool hovering;

    private ItemSO heldItem;
    private int itemAmount;

    private Image itemImage;
    private TextMeshProUGUI amountText;


    private void Awake()
    {
    }
    private void Initialize()
    {
        if (itemImage == null)
            itemImage = transform.GetChild(0).GetComponent<Image>();

        if (amountText == null)
            amountText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public ItemSO GetItem()
    {
        return heldItem;
    }

    public int GetAmount()
    {
        return itemAmount;
    }

    public void SetItem(ItemSO item, int amount)
    {
        heldItem = item;
        itemAmount = amount;
        UpdateSlots();
    }

    public void UpdateSlots()
    {
        Initialize();
        if (heldItem != null)
        {
            itemImage.sprite = heldItem.itemIcon;
            itemImage.enabled = true;
            amountText.text = itemAmount.ToString();
        }
        else
        {
            itemImage.enabled = false;
            amountText.text = "";
        }
    }

    public int AddAmount(int amountToAdd)
    {
        itemAmount += amountToAdd;
        UpdateSlots();
        return itemAmount;
    }

    public int RemoveAmount(int amountToRemove)
    {
        itemAmount -= amountToRemove;

        if (itemAmount <= 0)
            ClearSlots();
        else
            UpdateSlots();

        return itemAmount;
    }

    public void ClearSlots()
    {
        heldItem = null;
        itemAmount = 0;
        UpdateSlots();
    }

    public bool HasItem()
    {
        return heldItem != null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (heldItem == null)
            return;
        switch(eventData.button)
        {
            case PointerEventData.InputButton.Left:

                EquipItem();
                break;
            case PointerEventData.InputButton.Right:
                InspectItem();
                break;
        }

    }

    public void EquipItem()
    {
        switch(heldItem.itemType)
        {
            case ItemType.Gun:
            case ItemType.Axe:
                if(WeaponManager.Instance.isEquipped(heldItem))
                {
                    WeaponManager.Instance.Unequip();
                }
                else
                {
                    WeaponManager.Instance.Equip(heldItem);
                }
                break;

        }

    }
    public void InspectItem()
    {
        InspectManager.Instance.StartInspect(heldItem);

    }
}