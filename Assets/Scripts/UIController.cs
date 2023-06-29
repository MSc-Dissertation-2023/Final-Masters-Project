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
    [SerializeField] TMP_Text ammoLabel;

    [SerializeField] SettingsPopup settingsPopup;
    [SerializeField] EndGamePopup endGamePopup;

    private bool paused = false;

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
        endGamePopup.Open();
        Messenger.Broadcast(GameEvent.GAME_PAUSED);
    }

    public void OnOpenSettings()
    {
        settingsPopup.Open();
        Messenger.Broadcast(GameEvent.GAME_PAUSED);
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
        Messenger.AddListener(GameEvent.ENEMY_KILLED, OnEnemyKilled);
        Messenger.AddListener(GameEvent.GAME_END, OnEndGame);
        Messenger.AddListener(GameEvent.GAME_PAUSED, PauseGame);
        Messenger.AddListener(GameEvent.GAME_UNPAUSED, UnpauseGame);
        Messenger<float>.AddListener(GameEvent.UPDATE_HEALTH, UpdateHealthDisplay);
        Messenger<int>.AddListener(GameEvent.UPDATE_AMMO, UpdateAmmoDisplay);

    }
    void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_KILLED, OnEnemyKilled);
        Messenger.RemoveListener(GameEvent.GAME_END, OnEndGame);
        Messenger.RemoveListener(GameEvent.GAME_PAUSED, PauseGame);
        Messenger.RemoveListener(GameEvent.GAME_UNPAUSED, UnpauseGame);
        Messenger<float>.RemoveListener(GameEvent.UPDATE_HEALTH, UpdateHealthDisplay);
        Messenger<int>.RemoveListener(GameEvent.UPDATE_AMMO, UpdateAmmoDisplay);

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
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
}
