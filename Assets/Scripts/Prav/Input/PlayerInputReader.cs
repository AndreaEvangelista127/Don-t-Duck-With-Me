using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour, PlayerInput.ILocomotionActions
{
    [HideInInspector]
    public Vector2 PlayerMovementValue;
    public event Action OnPlayerDash;
    public event Action OnPlayerShoot;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Locomotion.AddCallbacks(this);
        playerInput.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        PlayerMovementValue = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnPlayerDash?.Invoke();
    }

    public void DisableMovement()
    {
        if (playerInput == null)
        {
            playerInput.Disable();
        }

    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnPlayerShoot?.Invoke();    
        }

    }
}
