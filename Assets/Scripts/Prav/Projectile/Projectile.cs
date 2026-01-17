using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void LaunchProjectile(Vector3 direction, float force)
    {
        playerRigidbody.linearVelocity = (direction * force);

        Destroy(gameObject, 3.0f);
    }


}
