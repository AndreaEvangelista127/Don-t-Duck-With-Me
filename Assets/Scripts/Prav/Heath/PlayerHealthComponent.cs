using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthComponent : MonoBehaviour
{

    [SerializeField] private Image _gameOverImage;
    private int currentHealth;
    private int maxHealth = 100;
    private FloatingHealthBar _healthBar;


    private void Start()
    {
        currentHealth = maxHealth;
        _healthBar = GetComponentInChildren<FloatingHealthBar>();
        _healthBar.UpdateHealthBarValue(currentHealth, maxHealth);

        _gameOverImage.gameObject.SetActive(false);
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

        _healthBar.UpdateHealthBarValue(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            _gameOverImage.gameObject.SetActive(true);
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
