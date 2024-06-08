using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMechanic : MonoBehaviour
{

    private bool isGrounded = true; // Variable to track if the player is grounded
    public bool IsJumping { get; private set; } = false;

    public float jumpForce = 5f;
    private bool wasSpacePressed = false;

    private Rigidbody rb;
    private PlayAnimations playAnimations;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        playAnimations = gameObject.GetComponent<PlayAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);
        // Check if the space key is pressed in the current frame
        bool isSpacePressed = Input.GetKeyDown(KeyCode.Space);
        // If space was pressed in the current frame and the player is grounded, initiate a jump
        if (isSpacePressed && isGrounded && !wasSpacePressed)
        {
            Jump(); // Call the Jump function
        }
        // Update the state of wasSpacePressed for the next frame
        wasSpacePressed = isSpacePressed;
    }

 

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player collides with a collider tagged as "Ground"
        if (collision.gameObject.CompareTag("floor"))
        {
            Debug.Log("STOP JUMP");
            IsJumping = false; // Reset isJumping when player lands on the ground
            isGrounded = true; // Set isGrounded to true
            //playAnimations.ResetAnimation("Jump");
        }
    }

    void Jump()
    {
        // playAnimations.StartAnimation("Jump", null);
        playAnimations.ChangeAnimationState("Jump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        IsJumping = true; // Set isJumping to true when jump is initiated
        isGrounded = false; // Set isGrounded to false when player jumps
    }
}
