using UnityEngine;

public class EnergyDrinkItem : BasePickUp
{
    [SerializeField] private float _attackSpeed;

    public override void PickUp(Collider2D c)
    {
        if (c.TryGetComponent(out PlayerCombat playerCombat))
        {
            playerCombat.SetFireRate(_attackSpeed);
        }
    }
}
