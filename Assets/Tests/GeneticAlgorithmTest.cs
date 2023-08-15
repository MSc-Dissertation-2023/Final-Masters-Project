using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

public class GeneticAlgorithmTest
{
    public GeneticAlgorithm GA;
    System.Random random;
    private int fitnessTarget;

    [SetUp]
    public void SetUp()
    {
        random = new System.Random();

        fitnessTarget = 5 * 5;


        GA = new GeneticAlgorithm(50, 5, 5, random, 0.125f);
        GA.NewGeneration();

        while (GA.bestFitness != fitnessTarget)
        {
            GA.NewGeneration();
        }
    }

    [Test]
    public void TestGAFitness()
    {
        Assert.AreEqual(GA.bestFitness, 5*5);
    }
}
