using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell mazeCellPrefab;

    [SerializeField] 
    private GameObject player;

    [SerializeField] 
    private GameObject enemy;

    [SerializeField] 
    private GameObject exit;

    [SerializeField]
    private int width;

    [SerializeField]
    private int depth;

    private MazeCell[,] grid;

    private List<MazeCell> UnvisitedCells; //Prim's Algorithm

    private List<MazeCell> VisitedCells; //Prim's Algorithm

    void Start()
    {
        grid = new MazeCell[width, depth];

        VisitedCells = new List<MazeCell>();
        UnvisitedCells = new List<MazeCell>();

        for (int x = 0; x < width; x++)
        {
            for(int z = 0; z < depth; z++)
            {
               grid[x,z] = Instantiate(mazeCellPrefab, new Vector3(x*5, 2.5f, z*5), Quaternion.identity);
               UnvisitedCells.Add(grid[x,z]); //Prim's Algorithm
            }
        }

        //GenerateMazeBacktracker(null, grid[0,0]); // Recursive Backtracker



        VisitedCells.Add(grid[0, 0]); //Prim's Algorithm
        UnvisitedCells.Remove(grid[0, 0]); //Prim's Algorithm
        grid[0, 0].VisitCell(); //Prim's Algorithm
        GenerateMazePrim(); //Prim's Algorithm


        float cornerValueWidth = 5f * (width - 1);
        float cornerValueDepth = 5f * (depth - 1);

        Instantiate(player, new Vector3(0f, 1.5f, 0f), Quaternion.identity);
        Instantiate(enemy, new Vector3(0f, 1.5f, cornerValueDepth), Quaternion.identity);
        Instantiate(enemy, new Vector3(cornerValueWidth, 1.5f, 0f), Quaternion.identity);
        Instantiate(exit, new Vector3(cornerValueWidth, 2.5f, cornerValueDepth + 2.5f), Quaternion.identity);
    }

    private void GenerateMazeBacktracker(MazeCell previous, MazeCell current)
    {
        current.VisitCell();
        ClearWalls(previous, current);

        MazeCell nextCell;

        do
        {
            nextCell = GetNextCell(current);

            if (nextCell != null)
            {
                GenerateMazeBacktracker(current, nextCell);
            }
        } while (nextCell != null);

        
    }

    private void GenerateMazePrim()
    {
        MazeCell current = choseRandomCell(VisitedCells);
        MazeCell nextCell = GetNextCell(current);

        if(nextCell != null)
        {
            ClearWalls(current, nextCell);
            nextCell.VisitCell();
            VisitedCells.Add(nextCell);
            UnvisitedCells.Remove(nextCell);
        }
        if(UnvisitedCells.Count > 0)
        {
            GenerateMazePrim();
        }
    }

    private MazeCell choseRandomCell(List<MazeCell> mazeCells)
    {
        return mazeCells[Random.Range(0, mazeCells.Count)];
    }

    private IEnumerable<MazeCell> GetUnvistedNeighbours(MazeCell current)
    {
        int x = (int)(current.transform.position.x)/5;
        int z = (int)(current.transform.position.z)/5;

        if (x + 1 < width)
        {
            var rightCell = grid[x + 1, z];

            if (rightCell.Visited == false)
            {
                yield return rightCell;
            }
            else
            {
                if (!rightCell.leftDestroyed)
                {
                    current.DestroyRight();
                    current.rightDestroyed = true;
                }
                
            }
        }

        if (x - 1 >= 0)
        {
            var leftCell = grid[x - 1, z];

            if (leftCell.Visited == false)
            {
                yield return leftCell;
            }
            else
            {
                if (!leftCell.rightDestroyed)
                {
                    current.DestroyLeft();
                    current.leftDestroyed = true;
                }
            }
        }

        if (z + 1 < depth)
        {
            var frontCell = grid[x, z + 1];

            if (frontCell.Visited == false)
            {
                yield return frontCell;
            }
            else
            {
                if (!frontCell.backDestroyed)
                {
                    current.DestroyFront();
                    current.frontDestroyed = true;
                }
            }
        }

        if (z- 1 >= 0)
        {
            var backCell = grid[x, z - 1];

            if(backCell.Visited == false)
            {
                yield return backCell;
            }
            else
            {
                if (!backCell.frontDestroyed)
                {
                    current.DestroyBack();
                    current.backDestroyed = true;
                }
            }
        }
    }

    private MazeCell GetNextCell(MazeCell current)
    {
        var unvisitedNeighbours = GetUnvistedNeighbours(current);
        return unvisitedNeighbours.OrderBy(x => Random.Range(1, 10)).FirstOrDefault();
    }

    private void ClearWalls(MazeCell previous, MazeCell current)
    {
        if (previous == null)
        {
            return;
        }

        if (previous.transform.position.x < current.transform.position.x)
        {
            previous.DestroyRight();
            current.DestroyLeft();
            return;
        }

        if (previous.transform.position.x > current.transform.position.x)
        {
            current.DestroyRight();
            previous.DestroyLeft();
            return;
        }

        if (previous.transform.position.z < current.transform.position.z)
        {
            previous.DestroyFront();
            current.DestroyBack();
            return;
        }

        if (previous.transform.position.z > current.transform.position.z)
        {
            previous.DestroyBack();
            current.DestroyFront();
            return;
        }

    }
}
