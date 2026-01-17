using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private Projectile projectileRef;

    [SerializeField]
    private AudioClip shootSound;

    private AudioSource audioSource;
    private PlayerInputReader playerInputReader;

    private void Awake()
    {
        playerInputReader = GetComponent<PlayerInputReader>();
        audioSource = GetComponent<AudioSource>();
        playerInputReader.OnPlayerShoot += HandleShooting;
    }

    private void HandleShooting()
    {
        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;

        audioSource.PlayOneShot(shootSound);

        Projectile projectile = Instantiate(projectileRef, transform.position, Quaternion.identity);
        projectile.LaunchProjectile(shootDirection, 10.0f);
    }
}
