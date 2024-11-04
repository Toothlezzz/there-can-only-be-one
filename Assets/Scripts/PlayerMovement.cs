using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;          // Maximum speed the player can reach
    public float acceleration = 2f;      // Rate of acceleration
    public float deceleration = 4f;      // Rate of deceleration
    private Rigidbody2D rb;
    [HideInInspector]
    public Vector2 moveDir;
    public Vector2 currentVelocity = Vector2.zero; // Current velocity of the player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        // Get input for movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Set the direction based on input
        moveDir = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        if (moveDir != Vector2.zero) // If there is input
        {
            // Check if the current velocity direction is different from the input direction
            if (Vector2.Dot(currentVelocity.normalized, moveDir) < 0.99f)
            {
                // If the input direction is different, snap to the new direction
                currentVelocity = moveDir * Mathf.Min(currentVelocity.magnitude, maxSpeed);
            }

            // Smoothly increase velocity towards the desired direction
            currentVelocity = Vector2.MoveTowards(currentVelocity, moveDir * maxSpeed, acceleration * Time.fixedDeltaTime);
        }
        else // If there is no input, decelerate
        {
            // Smoothly decrease velocity to zero
            currentVelocity = Vector2.MoveTowards(currentVelocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
        }

        // Set the rigidbody velocity
        rb.velocity = currentVelocity;
    }
}
