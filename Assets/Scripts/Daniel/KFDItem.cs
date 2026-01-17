using UnityEngine;

public class KFDItem : BasePickUp
{
    [SerializeField] private int _attackDamage;

    public override void PickUp(Collider2D c)
    {
        if (c.TryGetComponent(out PlayerCombat playerCombat))
        {
            playerCombat.SetDamageAmount(_attackDamage);
        }
    }
}
