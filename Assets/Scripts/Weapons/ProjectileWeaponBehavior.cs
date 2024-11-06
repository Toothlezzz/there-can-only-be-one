using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehavior : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    private HashSet<GameObject> hitEnemies = new HashSet<GameObject>(); // Set to track hit enemies

    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            GameObject enemyObject = col.gameObject;

            // Check if the enemy has already been hit
            if (!hitEnemies.Contains(enemyObject))
            {
                hitEnemies.Add(enemyObject); // Add to the set to avoid hitting the same enemy again

                // Apply damage to the enemy
                EnemyStats enemy = col.GetComponent<EnemyStats>();
                if (enemy != null)
                {
                    enemy.TakeDamage(currentDamage);
                }

                // Reduce pierce and check if the projectile should be destroyed
                ReducePierce();
            }
        }
    }

    void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}