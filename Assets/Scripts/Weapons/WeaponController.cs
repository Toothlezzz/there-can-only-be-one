using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;            // The arrow prefab
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;
    public int pierce;

    protected PlayerMovement pm;
    private bool isCharging;             // Track if the player is holding down the attack button

    // Start is called before the first frame update
    protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        currentCooldown = cooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) // Check if the left mouse button is pressed
        {
            isCharging = true;           // Start charging the attack
        }

        if (Input.GetMouseButtonUp(0) && currentCooldown <= 0) // When the left mouse button is released
        {
            if (isCharging)
            {
                Attack();
                isCharging = false;
            }
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = cooldownDuration;
    }
}

