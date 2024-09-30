using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonSettings : MonoBehaviour
{
    [Header("Game")]
    public int playerID;

    [Header("Stats")]
    public float PlayerHealth;
    [SerializeField] private float MaxHealth = 100;
    [Space(5)]

    public float PlayerStamina;
    public float MaxStamina = 100;
    public float StaminaDrainSpeed = 20f;
    public float StaminaRegenSpeed = 15f;
    [Space(5)]

    public float PlayerWalkSpeed = 0.5f;
    public float PlayerRunSpeed = 0.75f;
    [Space(5)]

    public float PlayerJumpPower = 7f;
    [Space(5)]

    public float PlayerHeight = 2;
    public float CrouchHeight = 1.4f;

    public void PlayerSpawned()
    {
        PlayerHealth = MaxHealth;
        PlayerStamina = MaxStamina;

        
    }

    void Start()
    {
        PlayerSpawned();
    }

    public void TakeDamage(float damage)
    {
        PlayerHealth -= damage;
    }
}
