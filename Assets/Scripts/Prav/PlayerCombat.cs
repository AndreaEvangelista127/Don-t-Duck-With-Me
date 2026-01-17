using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private Projectile projectileRef;

    [SerializeField]
    private AudioClip shootSound;

    [SerializeField]
    private float fireRate = .5f;

    private float timeToShoot = 0.0f;
    private int damageAmount = 30;

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

        if (Time.time > timeToShoot)
        {
            timeToShoot = Time.time + fireRate;
            Debug.Log($"Current Time: {Time.time} Time to shoot: {timeToShoot}");

            Vector3 shootDirection;
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection - transform.position;

            audioSource.PlayOneShot(shootSound);

            Projectile projectile = Instantiate(projectileRef, transform.position, Quaternion.identity);
            projectile.LaunchProjectile(shootDirection, 10.0f, damageAmount);
        }
        else
        {
            Debug.Log("Cannot ifre yet");
        }

    }

    public void SetDamageAmount(int amount)
    {
        this.damageAmount = amount;
    }
    public void SetFireRate(float fireRate)
    {
        this.fireRate = fireRate;
    }
}
