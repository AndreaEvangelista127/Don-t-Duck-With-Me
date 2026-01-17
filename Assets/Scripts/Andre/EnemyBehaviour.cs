using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;
    private FloatingHealthBar _healthBar;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 2f;

    [Header("Animation")]
    [SerializeField] private float wobbleSpeed = 5f;
    [SerializeField] private float wobbleAmplitude = 5f;

    [Header("Combat")]
    [SerializeField] private int _contactDamage = 10;
    [SerializeField] private float _damageRate = 1f; 
    private float _nextDamageTime = 0f;

    [SerializeField] private Transform artTransform;


    private Transform _player;
    private Rigidbody2D _rb;
    private Vector3 _startPosition;
    private float _bobTimer;

    private void Start()
    {
        _currentHealth = _maxHealth;
        
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        if(_player == null)
        {
            return;
        }

        _rb = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;

        _healthBar = GetComponentInChildren<FloatingHealthBar>();
        _healthBar.UpdateHealthBarValue(_currentHealth, _maxHealth);
    }

    private void FixedUpdate()
    {
        if (_player != null)
        {
            MoveTowardsPlayer();
        }
    }

    private void Update()
    {
        WobblingAnimation();
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        _rb.linearVelocity = direction * _moveSpeed;
    }

    private void WobblingAnimation()
    {
        float wobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmplitude;
        transform.rotation = Quaternion.Euler(0, 0, wobble);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.UpdateHealthBarValue(_currentHealth, _maxHealth);

        transform.DOPunchScale(Vector3.one * 2f, .25f);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Time.time >= _nextDamageTime)
        {
            PlayerHealthComponent playerHealth = collision.gameObject.GetComponent<PlayerHealthComponent>();
            if (playerHealth != null)
            {
                Debug.Log("im dealing dmg to you bastard");
                playerHealth.TakeDamage(_contactDamage);
                _nextDamageTime = Time.time + _damageRate;
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}