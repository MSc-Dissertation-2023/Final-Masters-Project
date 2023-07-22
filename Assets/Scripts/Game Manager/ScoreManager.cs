using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int Score { get; private set; }


    public void Startup()
    {
        Debug.Log("Score Manager manager starting...");

        Score = 0;

        status = ManagerStatus.Started;
    }

    public void AddToScore(int score)
    {
        Score += score;
    }
}