using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float health = 100;
    public int ammo = 50;
    public int damage = 25;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip hurtSound;

    public void UpdateData(float health, int ammo, int damage)
    {
        this.health = health;
        this.ammo = ammo;
        this.damage = damage;
        GameEvents.NotifyAmmo(ammo);
        GameEvents.NotifyHealth(health);
    }

    public void Start()
    {
        soundSource = GetComponent<AudioSource>();
        GameEvents.NotifyAmmo(ammo);
        GameEvents.NotifyHealth(health);
    }

    public void ConsumeAmmo()
    {
        if (ammo > 0)
        {
            ammo -= 1;
        }
        GameEvents.NotifyAmmo(ammo);
    }

    public void RestoreAmmo(int ammoAmt)
    {
        ammo += ammoAmt;
        GameEvents.NotifyHealth(health);
    }

    public void Hurt(float damage)
    {
        health -= damage;
        if (!soundSource.isPlaying)
        {
            soundSource.PlayOneShot(hurtSound);
        }
        else
        {
            soundSource.Stop();
            soundSource.PlayOneShot(hurtSound);

        }
        GameEvents.NotifyHealth(health);

        if (health <= 0)
        {
            GameEvents.NotifyEnd();
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

        GameEvents.NotifyHealth(health);
    }
}
