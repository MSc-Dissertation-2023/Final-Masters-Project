using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateMazeGA : MonoBehaviour
{
    private GeneticAlgorithm mazeGA;
    System.Random random;
    [SerializeField] int width;
    [SerializeField] int depth;
    [SerializeField] int populationSize;
    [SerializeField] float mutationRate;

    [SerializeField]
    private GameObject OuterWall;

    [SerializeField]
    private GameObject Wall;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private GameObject exit;

    private int fitnessTarget;

    void Start()
    {
        random = new System.Random();

        fitnessTarget = width * depth;


        mazeGA = new GeneticAlgorithm(populationSize, width, depth, random, mutationRate);
        mazeGA.NewGeneration();
        Debug.Log($"{mazeGA.bestFitness}");
        Debug.Log($"Generation: {mazeGA.generation}");

        while (mazeGA.bestFitness != fitnessTarget)
        {
            mazeGA.NewGeneration();
            Debug.Log($"{mazeGA.bestFitness}");
            Debug.Log($"Generation: {mazeGA.generation}");
        }

        Gene[,] bestGenes = mazeGA.bestGenes;

        for (int i = 0; i < width; i++)
        {
            Instantiate(OuterWall, new Vector3(i * 5, 2.5f, -2.5f), Quaternion.Euler(0, 90, 0));
            Instantiate(OuterWall, new Vector3(i * 5, 2.5f, depth * 5 - 2.5f), Quaternion.Euler(0, 90, 0));
        }
        for (int j = 0; j < depth; j++)
        {
            Instantiate(OuterWall, new Vector3(-2.5f, 2.5f, j * 5), Quaternion.identity);
            Instantiate(OuterWall, new Vector3(width * 5 - 2.5f, 2.5f, j * 5), Quaternion.identity);
        }

        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < depth; j++)
            {
                if (bestGenes[i, j].hasLeftWall())
                {
                    Instantiate(Wall, new Vector3((i * 5) - 2.5f, 2.5f, j * 5), Quaternion.identity);
                }
                if (bestGenes[i, j].hasRightWall())
                {
                    Instantiate(Wall, new Vector3((i * 5) + 2.5f, 2.5f, j * 5), Quaternion.identity);
                }
                if (bestGenes[i, j].hasFrontWall())
                {
                    Instantiate(Wall, new Vector3(i * 5, 2.5f, (j * 5) + 2.5f), Quaternion.Euler(0, 90, 0));
                }
                if (bestGenes[i, j].hasBackWall())
                {
                    Instantiate(Wall, new Vector3(i * 5, 2.5f,(j * 5) - 2.5f), Quaternion.Euler(0, 90, 0));
                }
            }
        }

        float cornerValueWidth = 5f * (width - 1);
        float cornerValueDepth = 5f * (depth - 1);

        Instantiate(player, new Vector3(0f, 1.5f, 0f), Quaternion.identity);
        Instantiate(enemy, new Vector3(0f, 1.5f, cornerValueDepth), Quaternion.identity);
        Instantiate(enemy, new Vector3(cornerValueWidth, 1.5f, 0f), Quaternion.identity);
        Instantiate(exit, new Vector3(cornerValueWidth, 2.5f, cornerValueDepth + 2.5f), Quaternion.identity);
    }
}
