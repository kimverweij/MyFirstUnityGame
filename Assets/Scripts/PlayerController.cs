using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 3f; // Speed for walking
    public float runSpeed = 6f; // Speed for running
    public float turnSpeed = 200f; // Speed for turning
    public float smoothingFactor = 0.5f; // Smoothing factor for movement and rotation

    private Rigidbody rb;
    private PlayAnimations playAnimations;
    private JumpMechanic jumpMechanic;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        jumpMechanic = gameObject.GetComponent<JumpMechanic>();
        playAnimations = gameObject.GetComponent<PlayAnimations>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        float currentSpeed = isShiftPressed ? runSpeed : walkSpeed;

        // Rotatie
        if (moveHorizontal != 0)
        {
            float rotation = moveHorizontal * turnSpeed * Time.fixedDeltaTime;
            Quaternion turnOffset = Quaternion.Euler(0, rotation, 0);
            rb.MoveRotation(rb.rotation * turnOffset);
        }

        // Voorwaartse beweging
        if (moveVertical > 0)
        {
            Vector3 movement = transform.forward * currentSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);

            // Update animaties
            if (!jumpMechanic.IsJumping)
            {
                if (isShiftPressed)
                {
                    playAnimations.ChangeAnimationState("Run");
                }
                else
                {
                    playAnimations.ChangeAnimationState("Walk");
                }
            }
        }
        else if (moveVertical == 0 && moveHorizontal == 0)
        {
            // Stop animaties als er geen beweging is
            if (!jumpMechanic.IsJumping)
            {
                playAnimations.ChangeAnimationState("Idle");
            }
        }

        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                Debug.Log("Key pressed: " + key);
            }
        }
    }
}
