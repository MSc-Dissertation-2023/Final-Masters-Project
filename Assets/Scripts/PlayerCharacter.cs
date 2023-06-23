using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private float health = 100;
    private UIController uiController;

    public void Start()
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();
        Debug.Log($"HP: {health}");
        uiController.UpdateHealthDisplay(health); // Update the display with the initial health
    }
    public void Hurt(float damage)
    {
        health -= damage;
        uiController.UpdateHealthDisplay(health);

        if (health <= 0)
        {
            Debug.Log("Dead");
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
