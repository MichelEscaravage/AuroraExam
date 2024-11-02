using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody Rigidbody;

    float horizontalMovement;
    float verticalMovement;

    [SerializeField] float horizontalSpeed;
    [SerializeField] float jumpHeight;

    bool jumped;
    GroundCheckerScript groundChecker;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        groundChecker = GetComponentInChildren<GroundCheckerScript>();  
    }

    // Update is called once per frame
    void Update()
    {
        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
        {
            jumped = true;
        }
    }

    private void FixedUpdate()
    {
        Rigidbody.velocity = new Vector3(horizontalMovement * horizontalSpeed, Rigidbody.velocity.y, verticalMovement * horizontalSpeed);

        if (jumped)
        {
            Rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jumped = false;
        }
    }

}
