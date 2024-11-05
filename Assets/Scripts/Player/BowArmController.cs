using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BowArmController : MonoBehaviour
{
    public Transform playerBody; // Reference to the player's body transform
    public SpriteRenderer bowArmRenderer; // SpriteRenderer for the bow arm
    public KeyCode attackKey = KeyCode.Mouse0; // Key for attacking, e.g., left mouse button

    public Vector2 rightOffset = new Vector2(0.5f, 0f); // Adjust this to fit your sprite
    public Vector2 leftOffset = new Vector2(-0.5f, 0f); // Adjust this to fit your sprite

    private bool isFacingLeft = false; // Track the character's facing direction

    void Start()
    {
        // Initialize the bow arm's position and flip state based on the initial facing direction
        InitializeBowArm();
    }

    void Update()
    {
        HandleVisibility();
        UpdateFacingDirection(); // Check for changes in the player's facing direction
        AimBow();
    }

    void InitializeBowArm()
    {
        // Set the initial facing direction based on player movement or a default state
        float initialMoveX = Input.GetAxisRaw("Horizontal");

        // Determine initial facing direction
        if (initialMoveX < 0)
        {
            isFacingLeft = true;
        }
        else
        {
            isFacingLeft = false;
        }

        // Apply the initial offset and flip state
        ApplyOffsetAndFlip();
    }

    void UpdateFacingDirection()
    {
        // Check the player's movement direction
        float moveX = Input.GetAxisRaw("Horizontal");

        // If the player is moving to the right and was previously facing left, flip to the right
        if (moveX > 0 && isFacingLeft)
        {
            isFacingLeft = false;
            ApplyOffsetAndFlip();
        }
        // If the player is moving to the left and was previously facing right, flip to the left
        else if (moveX < 0 && !isFacingLeft)
        {
            isFacingLeft = true;
            ApplyOffsetAndFlip();
        }
    }

    void ApplyOffsetAndFlip()
    {
        // Apply the appropriate offset and flip the sprite based on the facing direction
        if (isFacingLeft)
        {
            transform.localPosition = leftOffset; // Apply the left offset
            bowArmRenderer.flipY = true; // Flip the bow arm sprite
        }
        else
        {
            transform.localPosition = rightOffset; // Apply the right offset
            bowArmRenderer.flipY = false; // Unflip the bow arm sprite
        }
    }

    void AimBow()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the Z position is zero

        // Calculate the direction from the player to the mouse
        Vector3 direction = mousePosition - playerBody.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the bow arm to face the mouse direction
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    void HandleVisibility()
    {
        // Show the bow arm when the attack key is pressed, hide it otherwise
        if (Input.GetKey(attackKey))
        {
            bowArmRenderer.enabled = true; // Show the bow arm
        }
        else
        {
            bowArmRenderer.enabled = false; // Hide the bow arm
        }
    }
}