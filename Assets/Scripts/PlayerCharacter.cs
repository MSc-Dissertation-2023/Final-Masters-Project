using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float health = 100;
    public int ammo = 50;

    private UIController uiController;

    public void Start()
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();
        uiController.UpdateHealthDisplay(health); // Update the display with the initial health
        uiController.UpdateAmmoDisplay(ammo);
    }

    public void ConsumeAmmo()
    {
        if (ammo > 0)
        {
            ammo -= 1;
        }
        uiController.UpdateAmmoDisplay(ammo);
    }

    public void RestoreAmmo(int ammoAmt)
    {
        ammo += ammoAmt;
        uiController.UpdateAmmoDisplay(ammo);
    }

    public void Hurt(float damage)
    {
        health -= damage;
        uiController.UpdateHealthDisplay(health);

        if (health <= 0)
        {
            uiController.OnEndGame();
        }
    }

    public void Heal(float heal)
    {
        if (health + heal > 100)
        {
            health = 100;
        } else {
            health += heal;
        }
        
        uiController.UpdateHealthDisplay(health);
    }
}
