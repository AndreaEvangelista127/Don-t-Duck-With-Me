using UnityEngine;

public class CrossItem : BasePickUp
{
    [SerializeField] private int _playerHealth;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void PickUp()
    {
        TryGetComponent(out PlayerHealthComponent playerHealth);
        playerHealth.AddHealth(_playerHealth);
    }
}
