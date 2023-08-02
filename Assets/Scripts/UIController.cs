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
    [SerializeField] LevelCompletePopup endLevelPopup;
    [SerializeField] EnterCodePopup codePopup;

    private bool paused = false;
    private bool isGameEnded = false;

    void Start()
    {
        scoreLabel.text = Managers.Score.score.ToString();
        settingsPopup.Close();
        if (endLevelPopup != null)
        {
            endLevelPopup.Close();
        }
        if (codePopup != null)
        {
            codePopup.Close();
        }
        endGamePopup.Close();

    }

    public void OnEnemyKilled()
    {
        Managers.Score.AddToScore(1);
        scoreLabel.text = Managers.Score.score.ToString();
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
            finalScore.text = $"Score: {Managers.Score.score}";
            endGamePopup.Open();
        }
    }

    public void OnOpenSettings()
    {
        settingsPopup.Open();
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

    public void OpenCodeWindow()
    {
        codePopup.Open();
    }

    void OnEnable()
    {
        MazeEvents.ObjectiveReached += OpenCodeWindow;
        GameEvents.EnemyKilled += OnEnemyKilled;
        GameEvents.GamePaused += PauseGame;
        GameEvents.GameUnpaused += UnpauseGame;
        GameEvents.GameEnd += OnEndGame;
        GameEvents.UpdateHealth += UpdateHealthDisplay;
        GameEvents.UpdateAmmo += UpdateAmmoDisplay;
        GameEvents.LevelCompleted += OnLevelComplete;

    }
    void OnDisable()
    {
        MazeEvents.ObjectiveReached -= OpenCodeWindow;
        GameEvents.EnemyKilled -= OnEnemyKilled;
        GameEvents.GamePaused -= PauseGame;
        GameEvents.GameUnpaused -= UnpauseGame;
        GameEvents.GameEnd -= OnEndGame;
        GameEvents.UpdateHealth -= UpdateHealthDisplay;
        GameEvents.UpdateAmmo -= UpdateAmmoDisplay;
        GameEvents.LevelCompleted -= OnLevelComplete;

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

    private void OnLevelComplete(int health, int score)
    {
       endLevelPopup.Open();
        Debug.Log("On Level Complete");
    }
}
