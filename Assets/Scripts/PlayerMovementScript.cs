using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody Rigidbody;

    float horizontalMovement;
    float verticalMovement;

    [SerializeField] int maxJumps = 2; // Maximum jumps allowed
    [SerializeField] float horizontalSpeed;
    [SerializeField] float jumpHeight;

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

        // Check for jump input, ensuring there are jumps left
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            jumped = true;
            jumpsLeft--; // Decrease remaining jumps
        }
    }

    private void FixedUpdate()
    {
        Rigidbody.velocity = new Vector3(horizontalMovement * horizontalSpeed, Rigidbody.velocity.y, verticalMovement * horizontalSpeed);

        if (jumped)
        {
            groundChecker.StopCheck();
            Rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jumped = false;
        }

        // Only reset jumps if grounded and the stopCheck is false
        if (groundChecker.isGrounded && !groundChecker.stopCheck)
        {
            jumpsLeft = maxJumps;
        }
    }
}
