using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{
    [Header("Health UI Elements")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image delayeBar;
    [SerializeField] private float delayeSpeed = 1f;
    private float targetHealthFill;
    private float previousHealthFill;

    private void Update()
    {
      UpdateHealthUI();  
    }
    public void UpdateHealthUI()
    {
        targetHealthFill = (float) HealthManager.Instance.CurrentHealth / HealthManager.Instance.MaxHealth;
        healthBar.fillAmount = targetHealthFill;
        delayeBar.fillAmount = Mathf.Lerp(delayeBar.fillAmount, targetHealthFill, delayeSpeed * Time.deltaTime);
        if(targetHealthFill > previousHealthFill)
        {
               delayeBar.fillAmount = targetHealthFill;
        }
        else
        {
            delayeBar.fillAmount = Mathf.Lerp(delayeBar.fillAmount, targetHealthFill, delayeSpeed * Time.deltaTime);
        }
        previousHealthFill = targetHealthFill;
    }
}
