using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateMazeGA : MonoBehaviour
{
    private GeneticAlgorithm mazeGA;
    System.Random random;

    void Start()
    {
        random = new System.Random();
        /*
        mazeGA = new GeneticAlgorithm(10, 10, 10, random);
        mazeGA.NewGeneration();
        Debug.Log($"{mazeGA.bestFitness}");*/
        CandidateSolution cd = new CandidateSolution(10, 10, random);
        Debug.Log($"{cd.GetFitness()}");
        CandidateSolution cd1 = new CandidateSolution(10, 10, random);
        Debug.Log($"{cd1.GetFitness()}");
        CandidateSolution cd2 = new CandidateSolution(10, 10, random);
        Debug.Log($"{cd2.GetFitness()}");
        CandidateSolution cd3 = new CandidateSolution(10, 10, random);
        Debug.Log($"{cd3.GetFitness()}");
        CandidateSolution cd4 = new CandidateSolution(10, 10, random);
        Debug.Log($"{cd4.GetFitness()}");
    }
}
