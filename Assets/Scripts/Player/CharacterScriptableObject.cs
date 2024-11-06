using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Characters")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }
    //base stats for weapons
    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }
    [SerializeField]
    float recovery;
    public float Recovery { get => recovery; private set => recovery = value; }
    [SerializeField]
    float might;
    public float Might { get => might; private set => might = value; }
    [SerializeField]
    float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; private set => projectileSpeed = value; }

    [SerializeField]
    float maxSpeed;
    public float MaxSpeed { get => maxSpeed; private set => maxSpeed = value; }
    [SerializeField]
    float accelaration;
    public float Accelaration { get => accelaration; private set => accelaration = value; }
    [SerializeField]
    float decelaration;
    public float Decelaration { get => decelaration; private set => decelaration = value; }
}
