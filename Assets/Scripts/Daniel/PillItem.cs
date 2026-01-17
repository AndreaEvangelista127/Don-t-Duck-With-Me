using UnityEngine;

internal class PillItem : BasePickUp
{
    [SerializeField] private int _playerSanity;

    public override void PickUp(Collider2D c)
    {
        if (c.TryGetComponent(out InsanityMeter insanityMeter))
        {
            insanityMeter.AddInsanity(_playerSanity);
        }
    }
}
