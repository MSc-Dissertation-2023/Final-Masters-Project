using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    [SerializeField] public PlayerCharacter playerCharacter;
    ShootingMetrics shootingMetric;
    DamageMetrics damageMetric;

    float startingHealth = 100;
    int startingAmmo = 50;
    int startingDamage = 25;

    public float health => playerCharacter.health;
    public float ammo => playerCharacter.ammo;
    public float damage => playerCharacter.damage;

    void Awake()
    {
        // For Level 2
        if(GameObject.Find("Player Metrics") != null) {
            shootingMetric = GameObject.Find("Player Metrics").GetComponent<ShootingMetrics>();
            damageMetric = GameObject.Find("Player Metrics").GetComponent<DamageMetrics>();
        }
        // For Level 1
        if (playerCharacter != null)
        {
            playerCharacter.UpdateData(startingHealth, startingAmmo, startingDamage);
        }
    }

    public void Startup()
    {
        // For Level 1
        if (playerCharacter != null)
        {
            playerCharacter.UpdateData(startingHealth, startingAmmo, startingDamage);
        }
        status = ManagerStatus.Started;
    }

    public void ApplyDamage(float damage)
    {
        damageMetric.RegisterDamageTaken(damage);
        playerCharacter.Hurt(damage);
    }

    public void HealPlayer(float healAmount)
    {
        playerCharacter.Heal(healAmount);
    }

    public void GiveAmmo(int ammoAmount)
    {
        playerCharacter.RestoreAmmo(ammoAmount);
    }

    public void ConsumeAmmo()
    {
        if(shootingMetric != null) { shootingMetric.incrementShotsFired(); }
        playerCharacter.ConsumeAmmo();
    }

    public void IncreaseDamage(int amount)
    {
        playerCharacter.UpgradeDamage(amount);
    }

    public void OnSuccessfulShot()
    {
        if(shootingMetric != null) { shootingMetric.incrementShotsHit(); }
    }

    public static implicit operator PlayerManager(GameObject v)
    {
        throw new NotImplementedException();
    }

    // Implement other high-level player management functions here, such as switching players, saving player data, loading player data, etc...
}
