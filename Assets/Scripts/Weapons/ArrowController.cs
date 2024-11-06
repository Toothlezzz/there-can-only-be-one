using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();

        // Instantiate the arrow
        GameObject spawnedArrow = Instantiate(prefab);
        spawnedArrow.transform.position = transform.position;

        // Calculate the direction from the player to the mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        direction.z = 0; // Ensure the z value is 0 for 2D movement

        // Pass the direction to the ArrowBehavior script
        spawnedArrow.GetComponent<ArrowBehavior>().DirectionChecker(direction);
    }
}
