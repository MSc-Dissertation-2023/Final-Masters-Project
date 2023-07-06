using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    [SerializeField] public PlayerCharacter playerCharacter;
    [SerializeField] float maxHealth = 100;
    [SerializeField] int maxAmmo = 50;
    [SerializeField] int startingDamage = 25;

    public float health => playerCharacter.health;
    public float ammo => playerCharacter.ammo;
    public float damage => playerCharacter.damage;
    public int shotsFired = 0;
    public int shotsHit = 0;
    public float totalDamageTaken = 0;
    public float timeElapsed = 0;

    void Awake()
    {
        if (playerCharacter != null)
        {
            playerCharacter.UpdateData(maxHealth, maxAmmo, startingDamage);
        }
        
    }

    public void Startup()
    {
        if (playerCharacter != null)
        {
            playerCharacter.UpdateData(maxHealth, maxAmmo, startingDamage);
        }
        status = ManagerStatus.Started;
    }

    public void ApplyDamage(float damage)
    {
        totalDamageTaken += damage;
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
        shotsFired += 1;
        playerCharacter.ConsumeAmmo();
    }

    public void IncreaseDamage(int amount)
    {
        playerCharacter.UpgradeDamage(amount);
    }

    public void OnSuccessfulShot()
    {
        shotsHit += 1;
    }

    public float HitMissRatio()
    {
        return shotsHit / shotsFired;
    }

    public static implicit operator PlayerManager(GameObject v)
    {
        throw new NotImplementedException();
    }

    // Implement other high-level player management functions here, such as switching players, saving player data, loading player data, etc...
}
