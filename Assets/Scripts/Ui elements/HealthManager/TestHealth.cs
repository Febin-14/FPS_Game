using UnityEngine;

public class TestHealth : MonoBehaviour
{
    private int DamageAmount = 10;
    private int HealAmount = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            HealthManager.Instance.TakeDamage(DamageAmount);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            HealthManager.Instance.Heal(HealAmount);
        }
    }
}
