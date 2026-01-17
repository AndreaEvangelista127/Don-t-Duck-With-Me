using UnityEngine;

public class EnergyDrinkItem : BasePickUp
{
    [SerializeField] private int _attackSpeed;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void PickUp()
    {

    }
}
