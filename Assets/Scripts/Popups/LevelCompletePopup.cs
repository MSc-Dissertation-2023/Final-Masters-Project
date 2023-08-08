using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCompletePopup : MonoBehaviour
{
    private int RemainingAttempts;
    private int Time = 0;
    private int Score;

    [SerializeField] TMP_Text levelScore;

    [SerializeField, Header("Request time from scene controller to work out the score.")]
    private RequestScoreEvent requestScore;

    public void Open()
    {
        gameObject.SetActive(true);
        GameEvents.NotifyPaused();
        requestScore.Invoke();
        CalculateScore();
        Managers.Score.AddToScore(Score);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void proceed()
    {
        Managers.Player.SaveHealth();
        Manager.Data.SaveStats();
        gameObject.SetActive(false);
        GameEvents.NotifyUnpaused();
        Managers.Mission.GoToNext();
    }

    public void SetTime(int time)
    {
        Time = time;
    }

    private void CalculateScore()
    {
        Score = (2000 / Time);
        levelScore.text = $"Score: {Score}";
    }

    
}
