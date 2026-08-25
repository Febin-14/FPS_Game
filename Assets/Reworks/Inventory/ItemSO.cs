using UnityEngine;
    public enum ItemType
    {
        Normal,
        Key,
        Note,
        PuzzleItem,
        Gun,
        Axe

    }


[CreateAssetMenu(fileName = "Item Name", menuName = "NewItem")]
public class ItemSO : ScriptableObject
{
    // Description shown when inspecting the item
    [TextArea]
    public string itemDescription;

    public ItemType itemType;
    public string noteTitle;

    [TextArea(10,20)]
    public string noteContent;



    public int damageAmt;

    // Display name of the item
    public string itemName;

    // Icon displayed in the inventory UI
    public Sprite itemIcon;

    // Maximum number of this item that can be stacked in one slot
    // Example: Bullets = 50, Key = 1
    public int maxStackSize;

    // Prefab that exists in the game world and can be picked up
    public GameObject itemPrefab;

    // Prefab shown in the player's hand when equipped
    // Example: Flashlight, Gun, Crowbar
    public GameObject handItemPrefab;

    // Prefab used for inspecting the item in the inventory UI
    public GameObject inspectPrefab;

}