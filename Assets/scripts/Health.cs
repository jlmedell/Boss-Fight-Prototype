using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        FightOSC.Instance.SendHealth(currentHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        FightOSC.Instance.SendHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}