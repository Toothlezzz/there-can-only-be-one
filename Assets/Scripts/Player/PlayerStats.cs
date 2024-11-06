using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject characterData;
    float currentHealth;
    float currentRecovery;
    float currentMoveSpeed;
    float currentAcelaration;
    float currentDecelaration;
    float currentMight;
    float currentProjectileSpeed;

    private void Awake()
    {
        currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MaxSpeed;
        currentAcelaration = characterData.Accelaration;
        currentDecelaration = characterData.Decelaration;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
    }

}
