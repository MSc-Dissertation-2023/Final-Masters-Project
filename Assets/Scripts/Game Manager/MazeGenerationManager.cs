using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MazeGenerationManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public MazeAlgorithm Algorithm { get; private set; }

    public int Size { get; private set; }

    [SerializeField]
    private TMP_Text MazeSelector;

    [SerializeField]
    private TMP_Text MazeSize;

    public void Startup()
    {
        Debug.Log("Maze Generation Manager manager starting...");

        Algorithm = MazeAlgorithm.RecursiveBacktracker;

        Size = 10;

        status = ManagerStatus.Started;
    }

    public void SetAlgorithm()
    {
        if (MazeSelector.text.Equals("Recursive Backtracker"))
        {
            Algorithm = MazeAlgorithm.RecursiveBacktracker;
        }
        if (MazeSelector.text.Equals("Prim's Algorithm"))
        {
            Algorithm = MazeAlgorithm.PrimsAlgorithm;
        }
        if (MazeSelector.text.Equals("Recursive Division"))
        {
            Algorithm = MazeAlgorithm.RecursiveDivision;
        }
        if (MazeSelector.text.Equals("Genetic Algorithm"))
        {
            Algorithm = MazeAlgorithm.GeneticAlgorithm;
        }

        Debug.Log(Algorithm.ToString());
    }

    public void SetMazeSize()
    {
        if (MazeSize.text.Equals("Small"))
        {
            Size = 10;
        }
        if (MazeSize.text.Equals("Large"))
        {
            Size = 12;
        }
    }
}