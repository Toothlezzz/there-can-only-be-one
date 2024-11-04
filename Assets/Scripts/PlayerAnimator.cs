using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //References
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there is input or movement direction
        if (pm.moveDir != Vector2.zero && pm.currentVelocity.magnitude > 0.1f)
        {
            am.SetBool("Move", true);
        }
        else
        {
            am.SetBool("Move", false);
        }

        // Determine if the player is running or just walking
        if (pm.currentVelocity.magnitude > pm.maxSpeed * 0.6f) // Adjust the threshold as needed
        {
            am.SetBool("Run", true);
        }
        else
        {
            am.SetBool("Run", false);
        }

        // Optional: Flip the sprite based on movement direction
        if (pm.moveDir.x < 0)
        {
            sr.flipX = true;
        }
        else if (pm.moveDir.x > 0)
        {
            sr.flipX = false;
        }
    }
}
