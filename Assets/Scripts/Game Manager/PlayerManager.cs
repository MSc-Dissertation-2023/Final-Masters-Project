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

    void Awake()
    {
        playerCharacter.UpdateData(maxHealth, maxAmmo, startingDamage);
    }

    public void Startup() {
        playerCharacter.UpdateData(maxHealth, maxAmmo, startingDamage);
    }

    public void ApplyDamage(float damage)
    {
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
        playerCharacter.ConsumeAmmo();
    }

    public void IncreaseDamage(int amount)
    {
        playerCharacter.UpgradeDamage(amount);
    }

  public static implicit operator PlayerManager(GameObject v)
  {
    throw new NotImplementedException();
  }

  // Implement other high-level player management functions here, such as switching players, saving player data, loading player data, etc...
}
