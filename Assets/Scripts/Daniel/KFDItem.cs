using UnityEngine;

public class KFDItem : BasePickUp
{
    [SerializeField] private int _attackDamage;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void PickUp()
    {

    }
}
