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
    [SerializeField] GameObject playerPrefab;

    // public playerCharacter;

    void Awake()
    {
        Debug.Log("test");
        if (playerCharacter == null)
        {
            playerCharacter = Instantiate(playerPrefab).GetComponent<PlayerCharacter>();
            playerCharacter.name = "Player";
        }

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

  public static implicit operator PlayerManager(GameObject v)
  {
    throw new NotImplementedException();
  }

  // Implement other high-level player management functions here, such as switching players, saving player data, loading player data, etc...
}
