using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody Rigidbody;
    float horizontalMovement;
    float verticalMovement;
    private bool isDashing;
    private float dashEndTime;
    private float nextDashTime;

    [SerializeField] int maxJumps = 2; // Maximum jumps allowed
    [SerializeField] float horizontalSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] private float dashStrength = 10f;
    [SerializeField] private float dashDuration = 0.2f; // How long the dash lasts
    [SerializeField] private float dashCooldown = 1f;   // Cooldown between dashes
    [SerializeField] private float mouseSensitivity = 2f; // Adjust sensitivity for turning
    [SerializeField] private Transform cameraTransform;   // Reference to the camera (optional, for camera-based control)


    int jumpsLeft; // Remaining jumps available
    bool jumped;
    GroundCheckerScript groundChecker;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        groundChecker = GetComponentInChildren<GroundCheckerScript>();
        jumpsLeft = maxJumps; // Initialize remaining jumps
    }

    void Update()
    {
        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");

        // Handle turning with the right mouse button
        if (Input.GetMouseButton(1)) // Right mouse button held
        {
            TurnCharacterWithMouse();
        }

        // Check for jump input, ensuring there are jumps left
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            jumped = true;
            jumpsLeft--; // Decrease remaining jumps
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= nextDashTime)
        {
            StartDash();
        }
    }

    private void TurnCharacterWithMouse()
    {
        // Get the mouse's X-axis movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        // Rotate the character around the Y-axis based on mouse movement
        transform.Rotate(Vector3.up, mouseX);

        // Optional: Align the camera with the character's direction
        if (cameraTransform != null)
        {
            cameraTransform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        }
    }

    private void FixedUpdate()
    {
        // Handle movement based on the character's forward direction
        Vector3 movementDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        Rigidbody.velocity = new Vector3(
            movementDirection.x * horizontalSpeed,
            Rigidbody.velocity.y,
            movementDirection.z * horizontalSpeed
        );

        if (jumped)
        {
            // Only apply jump if the player is grounded or if double jump is allowed
            if (groundChecker.isGrounded || jumpsLeft < maxJumps)
            {
                groundChecker.StopCheck(); // Disable ground check temporarily
                Rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                jumped = false;
            }
        }

        if (isDashing)
        {
            Rigidbody.velocity = transform.forward * dashStrength;
            if (Time.time >= dashEndTime)
            {
                isDashing = false;
            }
        }

        // Reset jumps when grounded
        if (groundChecker.isGrounded && !groundChecker.stopCheck)
        {
            jumpsLeft = maxJumps; // Allow jumps again once grounded
        }
    }
    private void StartDash()
    {
        isDashing = true;
        dashEndTime = Time.time + dashDuration;
        nextDashTime = Time.time + dashCooldown;
    }
}