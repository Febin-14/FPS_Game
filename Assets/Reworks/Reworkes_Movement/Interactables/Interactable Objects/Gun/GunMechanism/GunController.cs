using System.Collections;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using System;
public class GunController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject hitEffectPrefab;
    private LayerMask hitMask;
    private ParticleSystem muzzleFlash;

    [Header("Gun Settings")]
    [SerializeField]   private float gunDamage = 25;
    [SerializeField]   private float gunRange = 10;
    [SerializeField]   private float fireRate = 2;
    private float nextFireTime;

    [Header("Ammo Settings")]
    [SerializeField] private int magazineSize = 8;
    [SerializeField] private int ammoInReserve = 32;
    private int currentAmmo;
    public int AmmoCount => currentAmmo;
    public int ReserveAmmoCount => ammoInReserve;

    [Header("Reload Settings")]
    [SerializeField]  private float reloadTime = 0.2f;
    private bool isReloading;

    public event  Action AmmoChanged;
    void Awake()
    {
        playerCamera = Camera.main;
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
         hitMask = LayerMask.GetMask("Ground", "Enemy");

       
    }
    void Start()
    {
        currentAmmo = magazineSize;
    }
    public void TryShoot()
    {
        if(!CanShoot())
        return;

        Shoot();
    }
    public void Shoot()
    {

        if(isReloading)
        return;

        Ray Ray = playerCamera.ViewportPointToRay(new Vector3(0.5f,0.5f));
        muzzleFlash.Play();
        if (Physics.Raycast(Ray, out RaycastHit hit, gunRange, hitMask))
        {
            Debug.Log("Hit: " + hit.collider.name);
            Debug.Log("Layer: " + LayerMask.LayerToName(hit.collider.gameObject.layer));
            GameObject effect = Instantiate(hitEffectPrefab, hit.point + hit.normal * 0.1f, Quaternion.LookRotation(hit.normal));
            Destroy(effect , 1f);

            EnemySystem enemy = hit.collider.GetComponent<EnemySystem>();
            if(enemy != null)
            {
                enemy.TakeDamage(gunDamage);
            }
        }
        // nextFireTime = Time.time + (1f / fireRate);
        currentAmmo--;
        AmmoChanged?.Invoke();

        Debug.Log("Ammo remaining: " + currentAmmo);

    }
    public void Reload()
    {
    
        Debug.Log("Reloading...");
        int ammoNeeded = magazineSize - currentAmmo;
        int ammoToReload = Mathf.Min(ammoNeeded, ammoInReserve);
        currentAmmo += ammoToReload;
        ammoInReserve -= ammoToReload;
        Debug.Log("Current Ammo: " + currentAmmo + ", Ammo in Reserve: " + ammoInReserve);
        AmmoChanged?.Invoke();

    }
    public void TryToReload()
    {
        Debug.Log("TryToReload Function entered");
        if(isReloading || currentAmmo >= magazineSize ||ammoInReserve <= 0)
        return;
        Debug.Log("Starting Reload Coroutine");
        StartCoroutine(ReloadCoroutine());

    }
    public bool CanShoot()
    {
        if(isReloading || currentAmmo <= 0)
        return false;
        else
        return true;
    }
    private IEnumerator ReloadCoroutine()
    {
        Debug.Log("Reload Coroutine started");
            isReloading = true;
            yield return new WaitForSeconds(reloadTime);
            Reload();
            isReloading = false;
            


    }


}
