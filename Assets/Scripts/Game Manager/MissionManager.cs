using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MissionManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int curLevel { get; private set; }
    public int maxLevel { get; private set; }

    public void Startup()
    {
        Debug.Log("Mission Manager manager starting...");

        curLevel = 0;
        maxLevel = 1;

        status = ManagerStatus.Started;
    }

    public void GoToNext()
    {
        Debug.Log("Loading");
        if (curLevel < maxLevel)
        {
            curLevel++;
            string name = $"Level{curLevel}";
            Debug.Log($"Loading {name}");
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.Log("Last level");
        }
    }
}