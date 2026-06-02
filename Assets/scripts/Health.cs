using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public string oscAddress = "/health";

    void Start()
    {
        currentHealth = maxHealth;
        FightOSC.Instance.SendHealth(oscAddress, currentHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " sends " + oscAddress + ": " + currentHealth + "/" + maxHealth);
        FightOSC.Instance.SendHealth(oscAddress, currentHealth, maxHealth);

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