using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthComponent : MonoBehaviour
{

    [SerializeField] private Image _gameOverImage;
    private int currentHealth;
    private int maxHealth = 100;
    private FloatingHealthBar _healthBar;

    private bool isDead;

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
    }

    public void TakeDamage(int health)
    {
        if (isDead) return;


        currentHealth -= health;

        _healthBar.UpdateHealthBarValue(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _gameOverImage.gameObject.SetActive(true);
        Destroy(gameObject);
    }

}
