using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartupController : MonoBehaviour
{
    [SerializeField] Slider progressBar;
    [SerializeField] StartScreen start;
    [SerializeField] LeaderboardPopup leaderboardPopup;
    [SerializeField] SettingsPopup settingsPopup;

    private bool gameReady;

    void Start()
    {
        gameReady = false;
        start.Open();
        leaderboardPopup.Close();
        settingsPopup.Close();
    }
    void OnEnable()
    {
        StartupEvents.ManagersStarted += OnManagersStarted;
        StartupEvents.ManagersProgress += OnManagersProgress;
    }

    void OnDiable()
    {
        StartupEvents.ManagersStarted -= OnManagersStarted;
        StartupEvents.ManagersProgress -= OnManagersProgress;
    }

    private void OnManagersProgress(int numReady, int numModules)
    {
        float progress = (float)numReady / numModules;
        progressBar.value = progress;
    }

    private void OnManagersStarted()
    {
        gameReady = true;
        Debug.Log("Game Ready");
    }

    public void StartGame()
    {
        if (gameReady)
        {
            Managers.Mission.GoToNext();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
