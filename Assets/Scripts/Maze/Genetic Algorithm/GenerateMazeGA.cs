using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateMazeGA : MonoBehaviour
{
    private GeneticAlgorithm mazeGA;
    System.Random random;
    private int width;
    private int depth;

    [SerializeField] int populationSize;
    [SerializeField] float mutationRate;

    [SerializeField]
    private GameObject Wall;

    private int fitnessTarget;

    [SerializeField, Header("Request maze sizes for generators.")]
    private RequestMazeSizesEvent RequestMazeSizes;

    [SerializeField, Header("Spawn prefabs into the maze.")]
    private SpawnPrefabsEvent SpawnPrefabs;

    [SerializeField, Header("Build the outer walls for the maze.")]
    private BuildOuterWallsEvent BuildOuterWalls;

    void Awake()
    {
        RequestMazeSizes.Invoke();
    }

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


        BuildOuterWalls.Invoke();

        for (int i = 0; i < width; i++)
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

        SpawnPrefabs.Invoke();
    }

    public void SetMazeSizes(int width, int depth)
    {
        this.width = width;
        this.depth = depth;
    }
}
