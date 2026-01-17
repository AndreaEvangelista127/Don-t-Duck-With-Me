using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerDataSO playerData;

    private PlayerInputReader playerInputReader;

    private Rigidbody2D playerRigidbody;

    private InsanityMeter playerInsanityMeter;

    private Vector2 playerMovementInput;
    private void Awake()
    {
        playerInputReader = GetComponent<PlayerInputReader>();
        playerRigidbody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (!playerInputReader)
        {
            Debug.LogWarning("Player Input Reader is null");
            return;
        }

        playerMovementInput = playerInputReader.PlayerMovementValue;
    }

    private void FixedUpdate()
    {
        HandleMovement(playerMovementInput, Time.fixedDeltaTime);
    }

    public void HandleMovement(Vector2 movementValue, float deltaTime)
    {
        Vector3 movementOffset = movementValue * playerData.PlayerSpeed * deltaTime;
        Vector2 targetPosition = playerRigidbody.position + (Vector2)movementOffset;

        playerRigidbody.MovePosition(targetPosition);
    }
    public void HandleDash()
    {

    }

    public void SetPlayerSpeed(float playerSpeed)
    {
        playerData.PlayerSpeed = playerSpeed;
    }
}