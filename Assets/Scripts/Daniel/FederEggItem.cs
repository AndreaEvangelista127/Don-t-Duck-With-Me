using UnityEngine;

public class FederEggItem : BasePickUp
{
    [SerializeField] private int _projectileSpeed;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void PickUp()
    {

    }
}
