using UnityEngine;

public class KFDItem : BasePickUp
{
    [SerializeField] private int _playerSanity;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void PickUp()
    {

    }
}
