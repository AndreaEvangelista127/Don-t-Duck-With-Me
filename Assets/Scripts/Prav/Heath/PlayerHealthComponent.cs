using UnityEngine;

public class PlayerHealthComponent : MonoBehaviour
{
    private int currentHealth;
    private int maxHealth = 100;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void AddHealth(int health)
    {
        currentHealth += health;

        if (currentHealth <= 0)
        {
            
        }
    }

    public void TakeDamage(int health)
    {
        currentHealth -= health;
    }



}
