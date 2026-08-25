using Unity.VisualScripting;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;
    [Header("Health Settings")]
    [SerializeField] private int maxHealth  =100 ;
    [SerializeField] private int currentHealth;
    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;


    private void Awake()
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
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damageAmount )
    {
        currentHealth -= damageAmount;
       
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void Death()
    {
        //Death Logic
        //Load death scene
    }
}



