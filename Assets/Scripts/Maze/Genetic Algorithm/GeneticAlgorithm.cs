using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneticAlgorithm
{
    public List<CandidateSolution> population { get; private set; }
    public int generation { get; private set; }
    public Gene[,] bestGenes { get; private set; }
    public int bestFitness { get; private set; }
    
    public float MutationRate;

    private System.Random random;
    public float totalCells;
    private int fitnessSum;

    public GeneticAlgorithm(int popSize, int width, int depth, System.Random random, float mutationRate = 0.05f)
    {
        totalCells = width * depth;
        generation = 1;
        this.random = random;
        MutationRate = mutationRate;
        population = new List<CandidateSolution>();
        bestGenes = new Gene[width, depth];

        for(int i = 0; i < popSize; i++)
        {
            population.Add(new CandidateSolution(width, depth, random));
        }
    }

    public void NewGeneration()
    {
        if (population.Count <= 0)
        {
            return;
        }

        CalculateFitness();

        List<CandidateSolution> newPopulation = new List<CandidateSolution>();

        for (int i = 0; i < population.Count; i++)
        {
            CandidateSolution parent = ChooseParent();
            newPopulation.Add(parent);

            CandidateSolution child = parent.mutate(MutationRate);
            newPopulation.Add(child);
        }

        population.Clear();
        population = newPopulation;

        generation++;
    }

    public void CalculateFitness()
    {
        fitnessSum = 0;
        CandidateSolution best = population[0];
        for(int i = 0; i < population.Count; i++)
        {
           fitnessSum += population[i].GetFitness();
            if (population[i].fitness > best.fitness)
            {
                best = population[i];
            }
        }

        bestFitness = best.fitness;
        bestGenes = best.Genes;


    }

    private CandidateSolution ChooseParent()
    {
        double randomNumber = random.NextDouble() * fitnessSum;

        for (int i = 0; i < population.Count; i++)
        {
            if(randomNumber < population[i].GetFitness())
            {
                return population[i];
            }

            randomNumber -= population[i].GetFitness();
        }
        return null;
    }

}

