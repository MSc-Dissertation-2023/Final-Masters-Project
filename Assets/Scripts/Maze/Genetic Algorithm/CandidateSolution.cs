using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CandidateSolution
{
    public Gene[,] Genes { get; private set; }
    public int fitness { get; private set; }
    private int width;
    private int depth;
    private System.Random random;

    public CandidateSolution(int width, int depth, System.Random random, bool shouldInitGenes = true)
    {
        this.width = width;
        this.depth = depth;
        Genes = new Gene[width, depth];
        this.random = random;
        fitness = 0;

        if(shouldInitGenes)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < depth; j++)
                {
                    Genes[i, j] = new Gene(GetRandomGene());
                }
            }
        }
    }

    public int GetFitness()
    {
        if (fitness == 0)
        {
            findReachableCells(0,0);
        }
        return fitness;
    }

    private void findReachableCells(int xPos, int zPos)
    {
        Genes[xPos, zPos].visitCell();
        fitness++;
        foreach(int[] cell in getReachableNeighbours(xPos, zPos))
        {
            findReachableCells(cell[0], cell[1]);
        }

    }

    public CandidateSolution mutate(float mutationProb)
    {
        CandidateSolution child = new CandidateSolution(width, depth, random, shouldInitGenes: false);
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < depth; j++)
            {
                if (random.NextDouble() < mutationProb)
                {
                    child.Genes[i, j] = new Gene(GetRandomGene()); 
                }
                else
                {
                    child.Genes[i, j] = new Gene(Genes[i, j].getGenotype());
                }
            }
        }
        
        return child;
    }

    private int GetRandomGene()
    {
        return UnityEngine.Random.Range(0, 14);
    }

    private IEnumerable<int[]> getReachableNeighbours(int xPos, int zPos)
    {
        if (xPos + 1 < width)
        {
            var rightCell = Genes[xPos + 1, zPos];

            if (!rightCell.hasLeftWall() && !Genes[xPos, zPos].hasRightWall() && !rightCell.IsVisited())
            {
                int[] right = {xPos + 1, zPos};
                yield return right;
            }
        }
        if (xPos - 1 >= 0)
        {
            var leftCell = Genes[xPos - 1, zPos];

            if (!leftCell.hasRightWall() && !Genes[xPos, zPos].hasLeftWall() && !leftCell.IsVisited())
            {
                int[] left = { xPos - 1, zPos};
                yield return left;
            }
        }
        if (zPos + 1 < depth)
        {
            var frontCell = Genes[xPos, zPos + 1];

            if (!frontCell.hasBackWall() && !Genes[xPos, zPos].hasFrontWall() && frontCell.IsVisited())
            {
                int[] front = {xPos, zPos + 1};
                yield return front;
            }
        }
        if (zPos - 1 >= 0)
        {
            var backCell = Genes[xPos, zPos - 1];

            if (!backCell.hasFrontWall() && !Genes[xPos, zPos].hasBackWall() && backCell.IsVisited())
            {
                int[] back = {xPos, zPos - 1};
                yield return back;
            }
        }
    }
}
