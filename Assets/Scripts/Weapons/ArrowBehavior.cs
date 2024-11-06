using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : ProjectileWeaponBehavior
{
    ArrowController ac;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ac = FindObjectOfType<ArrowController>();

        // Rotate the arrow sprite to face the direction
        RotateArrow();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the arrow in the given direction
        transform.position += direction * ac.speed * Time.deltaTime;
    }

    // Method to rotate the arrow sprite
    void RotateArrow()
    {
        // Calculate the angle between the direction vector and the right vector (1, 0)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the arrow sprite to face the direction
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
