using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class InspectManager : MonoBehaviour
{
    public static InspectManager Instance;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject inspectPanel;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    
   

    private GameObject currentObject;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartInspect(ItemSO item)
    {
        GameManager.Instance.SetState(GameState.Inspecting);
        if(item != null)
        {
            inspectPanel.SetActive(true);
            Destroy(currentObject);
        }

        currentObject = Instantiate(item.inspectPrefab, spawnPoint.transform.position, Quaternion.identity);
        itemNameText.text = item.itemName;
        itemDescriptionText.text = item.itemDescription;
        inventoryUI.SetActive(false);

    }
    public GameObject CurrentObject
    {
        get { return currentObject; }
    }
    public void StopInspect()
    {
        GameManager.Instance.SetState(GameState.Inventory);
        inspectPanel.SetActive(false);
        inventoryUI.SetActive(true);
        Destroy(currentObject);
    }
    public void RefreshInspectUI()
    {
        if(currentObject == null)
        {
            itemDescriptionText.text = "";
            itemNameText.text = "";
        }
    }
   
}
