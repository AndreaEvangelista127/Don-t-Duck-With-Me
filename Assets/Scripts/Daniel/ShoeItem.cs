using UnityEngine;

internal class ShoeItem : BasePickUp
{
    [SerializeField] private int _playerSpeed;


    public override void PickUp(Collider2D c)
    {
        if (c.TryGetComponent(out PlayerController playerController))
        {
            playerController.SetPlayerSpeed(_playerSpeed);
        }
    }
}
