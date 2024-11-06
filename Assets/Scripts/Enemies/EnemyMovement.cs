using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BatMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform; // Find the player
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component

        // Ensure the Rigidbody2D is set up correctly
        rb.gravityScale = 0; // Disable gravity
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Freeze rotation to prevent spinning
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the movement direction towards the player
        movementDirection = (player.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        // Use Rigidbody2D to move towards the player, applying movement as velocity
        rb.velocity = movementDirection * enemyData.MoveSpeed;
    }
}


