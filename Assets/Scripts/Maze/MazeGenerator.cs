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

    void Start()
    {
        grid = new MazeCell[width, depth];

        for (int x = 0; x < width; x++)
        {
            for(int z = 0; z < depth; z++)
            {
               grid[x,z] = Instantiate(mazeCellPrefab, new Vector3(x*5, 2.5f, z*5), Quaternion.identity);
            }
        }

        GenerateMaze(null, grid[0,0]);

        Instantiate(player, new Vector3(0f, 1.5f, 0f), Quaternion.identity);
        Instantiate(enemy, new Vector3(0f, 1.5f, 70f), Quaternion.identity);
        Instantiate(enemy, new Vector3(70f, 1.5f, 0f), Quaternion.identity);
        Instantiate(exit, new Vector3(70f, 2.5f, 70f), Quaternion.identity);
    }

    private void GenerateMaze(MazeCell previous, MazeCell current)
    {
        current.VisitCell();
        ClearWalls(previous, current);

        MazeCell nextCell;

        do
        {
            nextCell = GetNextCell(current);

            if (nextCell != null)
            {
                GenerateMaze(current, nextCell);
            }
        } while (nextCell != null);

        
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
        }

        if (x - 1 >= 0)
        {
            var leftCell = grid[x - 1, z];

            if (leftCell.Visited == false)
            {
                yield return leftCell;
            }
        }

        if (z + 1 < depth)
        {
            var frontCell = grid[x, z + 1];

            if (frontCell.Visited == false)
            {
                yield return frontCell;
            }
        }

        if (z- 1 >= 0)
        {
            var backCell = grid[x, z - 1];

            if(backCell.Visited == false)
            {
                yield return backCell;
            }
        }
    }

    private MazeCell GetNextCell(MazeCell current)
    {
        var unvisitedNeighbours = GetUnvistedNeighbours(current);
        return unvisitedNeighbours.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
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
