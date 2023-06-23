using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/*
 * A class to track score and display in HUD
 */
public class UIController : MonoBehaviour
{
    //Score label
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] TMP_Text healthLabel;

    [SerializeField] SettingsPopup settingsPopup;
    [SerializeField] EndGamePopup endGamePopup;

    private int score;

    void Start()
    {
        score = 0;
        scoreLabel.text = score.ToString();
        settingsPopup.Close();
        endGamePopup.Close();
    }

    public void OnEnemyKilled()
    {
        score += 1;
        scoreLabel.text = score.ToString();
    }

    public void UpdateHealthDisplay(float health)
    {
        healthLabel.text = $"HP: {health}";
    }

    public void OnEndGame()
    {
        endGamePopup.Open();    
    }

    public void OnOpenSettings()
    {
        settingsPopup.Open();
    }
}
