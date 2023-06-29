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

    public void Start()
    {
        soundSource = GetComponent<AudioSource>();
        Messenger<int>.Broadcast(GameEvent.UPDATE_AMMO, ammo); // Update the display with the initial health
        Messenger<float>.Broadcast(GameEvent.UPDATE_HEALTH, health);
    }

    public void ConsumeAmmo()
    {
        if (ammo > 0)
        {
            ammo -= 1;
        }
        Messenger<int>.Broadcast(GameEvent.UPDATE_AMMO, ammo);
    }

    public void RestoreAmmo(int ammoAmt)
    {
        ammo += ammoAmt;
        Messenger<int>.Broadcast(GameEvent.UPDATE_AMMO, ammo);
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
        Messenger<float>.Broadcast(GameEvent.UPDATE_HEALTH, health);

        if (health <= 0)
        {
            Messenger.Broadcast(GameEvent.GAME_END);
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

        Messenger<float>.Broadcast(GameEvent.UPDATE_HEALTH, health);
    }
}
