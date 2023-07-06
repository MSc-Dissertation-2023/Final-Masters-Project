using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public float health { get; private set; }
    public float maxHealth { get; private set; }


    public void Startup()
    {

        if(playerCharacter != null)
        {
            playerCharacter.UpdateData(maxHealth, maxAmmo, startingDamage);
        }

        status = ManagerStatus.Started;
    }

    public void Startup()
    {
        if (playerCharacter != null)
        {
            playerCharacter.UpdateData(maxHealth, maxAmmo, startingDamage);
        }
    }

    public void ApplyDamage(float damage)
    { 

        health = 50;
        maxHealth = 100;
        status = ManagerStatus.Started;
    }

    public void ChangeHealth(float value)

    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        } else if (health < 0)
        {
            health = 0;
        }

        Debug.Log($"Health: {health}/{maxHealth}");
    }
}
