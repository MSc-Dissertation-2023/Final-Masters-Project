using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MazeGeneratorDivision : MonoBehaviour
{
    [SerializeField]
    private GameObject OuterWall;

    [SerializeField]
    private GameObject Wall;

    [SerializeField]
    private int width;

    [SerializeField]
    private int depth;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private GameObject exit;

    private List<Chamber> chambers;

    void Start()
    {
        for(int i = 0; i < width; i++)
        {
            Instantiate(OuterWall, new Vector3(i * 5, 2.5f, -2.5f), Quaternion.Euler(0, 90, 0));
            Instantiate(OuterWall, new Vector3(i * 5, 2.5f, depth * 5 - 2.5f), Quaternion.Euler(0, 90, 0));
        }
        for(int j = 0; j < depth; j++)
        {
            Instantiate(OuterWall, new Vector3(-2.5f, 2.5f, j * 5), Quaternion.identity);
            Instantiate(OuterWall, new Vector3(width * 5 - 2.5f, 2.5f, j * 5), Quaternion.identity);
        }

        chambers = new List<Chamber>();
        chambers.Add(new Chamber(width, depth, 0f, 0f));

        while (chambers.Count > 0)
        {
            Chamber chamber = GetSmallestChamber();
            chambers.Remove(chamber);
            Divide(chamber);
        }

        float cornerValueWidth = 5f * (width - 1);
        float cornerValueDepth = 5f * (depth - 1);

        Instantiate(player, new Vector3(0f, 1.5f, 0f), Quaternion.identity);
        Instantiate(enemy, new Vector3(0f, 1.5f, cornerValueDepth), Quaternion.identity);
        Instantiate(enemy, new Vector3(cornerValueWidth, 1.5f, 0f), Quaternion.identity);
        Instantiate(exit, new Vector3(cornerValueWidth, 2.5f, cornerValueDepth + 2.5f), Quaternion.identity);
    }

    private string ChooseOrientation(int width, int height)
    {
        if (width < height)
        {
            return "Hor";
        }
        else if (height < width)
        {
            return "Ver";
        }
        else
        {
            return Random.Range(0, 2) == 0 ? "Hor" : "Ver";
        }
    }

    private void Divide(Chamber chamber)
    {
        int width = chamber.GetWidth();
        int height = chamber.GetHeight();
        float xPos = chamber.GetXPos();
        float yPos = chamber.GetYPos();
        if (width < 2 || height < 2)
        {
            return;
        }

        string orientation = ChooseOrientation(width, height);
        int passage;
        int passage2;

        if (orientation.Equals("Hor"))
        {
            int divide = Random.Range(1, height);
            if(width > 5)
            {
                passage = Random.Range(0, width/2);
                passage2 = Random.Range(width / 2, width);
            }
            else
            {
                passage = Random.Range(0, width);
                passage2 = -1;
            }
            

            for (int i = 0; i < width; i++)
            {
                if (i != passage && i != passage2)
                {
                    Instantiate(Wall, new Vector3(xPos + i * 5, 2.5f, yPos + divide * 5 - 2.5f), Quaternion.Euler(0, 90, 0));
                }
            }
            chambers.Add(new Chamber(width, divide, xPos, yPos));
            chambers.Add(new Chamber(width, height - divide, xPos, yPos + divide * 5));
        }
        else if (orientation.Equals("Ver"))
        {
            int divide = Random.Range(1, width);
            if (height > 5)
            {
                passage = Random.Range(0, height / 2);
                passage2 = Random.Range(height / 2, height);
            }
            else
            {
                passage = Random.Range(0, height);
                passage2 = -1;
            }

            for (int i = 0; i < height; i++)
            {
                if (i != passage && i != passage2)
                {
                    Instantiate(Wall, new Vector3(xPos + divide * 5 - 2.5f, 2.5f, yPos + i * 5), Quaternion.identity);
                }
            }
            chambers.Add(new Chamber(divide, height, xPos, yPos));
            chambers.Add(new Chamber(width - divide, height, xPos + divide * 5, yPos));
        }
    }

    private Chamber GetSmallestChamber()
    {
        return chambers.OrderBy(chamber => chamber.GetSize()).FirstOrDefault();
    }

    private void CreateLoops(int destroyPercentage)
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("MazeWall");

        for(int i = 0; i < walls.Length; i++ )
        {
            int value = Random.Range(0, 100);
            if (value < destroyPercentage)
            {
                walls[i].SetActive(false);
            }
        }


    }
}
