using UnityEngine;

public class WingItem : BasePickUp
{
    [SerializeField] private int _dashValue;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void PickUp()
    {

    }
}
