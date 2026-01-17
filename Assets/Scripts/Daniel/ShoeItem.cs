using UnityEngine;

internal class ShoeItem : BasePickUp
{
    [SerializeField] private int _playerSpeed;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision);
    }

    public override void PickUp()
    {
        TryGetComponent(out PlayerController playerController);
        playerController.SetPlayerSpeed(_playerSpeed);
    }
}
