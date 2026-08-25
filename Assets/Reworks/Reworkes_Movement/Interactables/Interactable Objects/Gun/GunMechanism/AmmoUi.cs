using UnityEngine;

public class AmmoUi : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TMPro.TextMeshProUGUI ammoText;
    [SerializeField] private TMPro.TextMeshProUGUI reserveAmmoText;
    [SerializeField] private TMPro.TextMeshProUGUI ReloadText;
    [SerializeField] private TMPro.TextMeshProUGUI slashText;
    public void updateAmmoUi(int currentAmmo, int reserveAmmo)
    {
        ammoText.text = currentAmmo.ToString();
        reserveAmmoText.text = reserveAmmo.ToString();
    }

    public void ShowReloadText()
    {
        ReloadText.gameObject.SetActive(true);
    }
    public void HideReloadText()
    {
        ReloadText.gameObject.SetActive(false);
    }
    public void EnableAmmoUI()
    {
        ammoText.gameObject.SetActive(true);
        reserveAmmoText.gameObject.SetActive(true);
        slashText.gameObject.SetActive(true);
    }

    public void DisableAmmoUI()
    {
        ammoText.gameObject.SetActive(false);
        reserveAmmoText.gameObject.SetActive(false);
        slashText.gameObject.SetActive(false);
    }
    
}
