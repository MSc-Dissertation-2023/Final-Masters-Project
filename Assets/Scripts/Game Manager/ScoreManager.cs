using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int score { get; private set; }


    public void Startup()
    {
        Debug.Log("Score Manager manager starting...");

        score = 0;

        status = ManagerStatus.Started;
    }

    public void AddToScore(int value)
    {
        score += value;
    }
}