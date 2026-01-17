using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private int damageAmount;
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void LaunchProjectile(Vector3 direction, float force, int damage)
    {
        playerRigidbody.linearVelocity = (direction * force);
        damageAmount = damage;
        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damageAmount);
            Destroy(gameObject);
        }

    }


}
