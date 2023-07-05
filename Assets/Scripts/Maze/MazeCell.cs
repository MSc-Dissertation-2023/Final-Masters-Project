using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject leftWall;

    [SerializeField]
    private GameObject rightWall;

    [SerializeField]
    private GameObject frontWall;

    [SerializeField]
    private GameObject backWall;

    [SerializeField]
    private GameObject block;

    public bool Visited { get; private set; }

    public void VisitCell()
    {
        Visited = true;
        block.SetActive(false);
    }

    public void DestroyLeft()
    {
        leftWall.SetActive(false);
    }

    public void DestroyRight()
    {
        rightWall.SetActive(false);
    }

    public void DestroyFront()
    {
        frontWall.SetActive(false);
    }

    public void DestroyBack()
    {
        backWall.SetActive(false);
    }
}
