using UnityEngine;

public class CrossItem : BasePickUp
{
    [SerializeField] private int _playerHealth;

    public override void PickUp(Collider2D c)
    {
        if (c.TryGetComponent(out PlayerHealthComponent playerHealth))
        {
            playerHealth.AddHealth(_playerHealth);
        }
    }
}
