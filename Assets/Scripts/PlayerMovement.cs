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

    // Collider references
    private BoxCollider2D boxCollider;

    // Offset values for facing right and left
    public Vector2 rightFacingOffset = new Vector2(-0.05f, 0f); // Offset when facing right
    public Vector2 leftFacingOffset = new Vector2(0.05f, 0f);    // Offset when facing left

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>(); // Get the BoxCollider2D component
    }

    void Update()
    {
        InputManagement();
        AdjustColliderOffset(); // Adjust the collider offset based on movement direction
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

    // Adjusts the BoxCollider2D offset based on movement direction
    void AdjustColliderOffset()
    {
        // Get the current Y offset to retain it
        float currentYOffset = boxCollider.offset.y;

        // Check the direction and set the X offset accordingly while keeping the Y offset the same
        if (moveDir.x > 0) // Facing right
        {
            boxCollider.offset = new Vector2(rightFacingOffset.x, currentYOffset);
        }
        else if (moveDir.x < 0) // Facing left
        {
            boxCollider.offset = new Vector2(leftFacingOffset.x, currentYOffset);
        }
    }
}