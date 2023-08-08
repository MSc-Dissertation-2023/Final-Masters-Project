using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public PlayerCharacter playerCharacter;
    ShootingMetrics shootingMetric;
    DamageMetrics damageMetric;

    float Health = 100;
    int Ammo = 50;
    int Damage = 25;

    public float health => playerCharacter.health;
    public int ammo => playerCharacter.ammo;
    public int damage => playerCharacter.damage;

 

    public void Startup()
    {
        status = ManagerStatus.Started;
    }

    public void ApplyDamage(float damage)
    {
        playerCharacter.Hurt(damage);
        if (damageMetric != null) {
            damageMetric.RegisterDamageTaken(damage);
            damageMetric.incrementHitsTaken();
        }
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


    public void OnSceneLoaded()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        
        // For Level 2
        if (GameObject.Find("Player Metrics") != null)
        {
            shootingMetric = GameObject.Find("Player Metrics").GetComponent<ShootingMetrics>();
            damageMetric = GameObject.Find("Player Metrics").GetComponent<DamageMetrics>();
        }
        
        if (playerCharacter != null)
        {
            playerCharacter.UpdateData(Health, Ammo, Damage);
        }
    }

    public void SaveHealth()
    {
        Health = health;
    }

    // Implement other high-level player management functions here, such as switching players, saving player data, loading player data, etc...
}
