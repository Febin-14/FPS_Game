using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;
    [SerializeField] private Transform WeaponHolder;
    public GameObject currentWeapon;
    public ItemSO equippedItem;
    public GunController currentGun;
    private InputManager _inputManager;


    [Header("UI References")]
    [SerializeField] private AmmoUi ammoUi;

    public void Update()
    {
        TryReload();
    }
    private void Awake()
    {
        _inputManager = FindObjectOfType<InputManager>();
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Equip(ItemSO item)
    {
        if(equippedItem == item)
         return;
    

        Unequip();
        currentWeapon = Instantiate(item.handItemPrefab,WeaponHolder);
        equippedItem = item;
        currentGun = currentWeapon.GetComponent<GunController>();
        currentGun.AmmoChanged += UpdateAmmoUI;
        ammoUi.EnableAmmoUI();
        
        ParticleSystemRenderer psr = currentWeapon.GetComponentInChildren<ParticleSystemRenderer>();


    }
    public void Unequip()
    {
        if(currentWeapon != null)
        {
            currentGun.AmmoChanged -= UpdateAmmoUI;
            Destroy(currentWeapon);
            currentWeapon = null;
            ammoUi.DisableAmmoUI();
        }
        currentGun = null;
        equippedItem = null;
    }
    public bool isEquipped(ItemSO item)
    {
        return equippedItem == item;
    }
    public void Shoot()
    {
        if(currentGun != null)
        {
            Debug.Log("Try Shoot Called");
            currentGun.TryShoot();

        }
    }

    public void TryReload()
    {

        if(_inputManager.ReloadInput)
        {
            Debug.Log("Reload Input Detected");
            if(currentGun != null)
            {
            currentGun.TryToReload();
   
            }
            _inputManager.ConsumeReload();
            
        }
    }
    public void UpdateAmmoUI()
    {
        if(currentGun != null)
        {
            ammoUi.updateAmmoUi(currentGun.AmmoCount, currentGun.ReserveAmmoCount);
        }
    }
}
