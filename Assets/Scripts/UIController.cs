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
    [SerializeField] TMP_Text finalScore;


    [SerializeField] TMP_Text healthLabel;
    [SerializeField] TMP_Text ammoLabel;

    [SerializeField] SettingsPopup settingsPopup;
    [SerializeField] EndGamePopup endGamePopup;

    private bool paused = false;
    private bool isGameEnded = false;

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

    public void UpdateAmmoDisplay(int ammo)
    {
        ammoLabel.text = $"Ammo: {ammo}";
    }

    public void OnEndGame()
    {

        if (!isGameEnded) {
            isGameEnded = true;
            finalScore.text = $"Score: {score}";
            endGamePopup.Open();
            GameEvents.NotifyPaused();
        }
    }

    public void OnOpenSettings()
    {
        settingsPopup.Open();
        GameEvents.NotifyPaused();
    }

    public void Update()
    {
        if (!paused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnOpenSettings();
            }
        }

    }
    void OnEnable()
    {
        GameEvents.EnemyKilled += OnEnemyKilled;
        GameEvents.GamePaused += PauseGame;
        GameEvents.GameUnpaused += UnpauseGame;
        GameEvents.GameEnd += OnEndGame;
        GameEvents.UpdateHealth += UpdateHealthDisplay;
        GameEvents.UpdateAmmo += UpdateAmmoDisplay;

    }
    void OnDisable()
    {
        GameEvents.EnemyKilled -= OnEnemyKilled;
        GameEvents.GamePaused -= PauseGame;
        GameEvents.GameUnpaused -= UnpauseGame;
        GameEvents.GameEnd -= OnEndGame;
        GameEvents.UpdateHealth -= UpdateHealthDisplay;
        GameEvents.UpdateAmmo -= UpdateAmmoDisplay;

    }

    private void PauseGame()
    {
        paused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    private void UnpauseGame()
    {
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}
