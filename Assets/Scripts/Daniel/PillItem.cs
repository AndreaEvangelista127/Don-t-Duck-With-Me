using UnityEngine;

internal class PillItem : BasePickUp
{
    [SerializeField] private int _playerSanity;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision);
    }

    public override void PickUp()
    {
        TryGetComponent(out InsanityMeter insanityMeter);
        insanityMeter.AddInsanity(_playerSanity);
    }
}
