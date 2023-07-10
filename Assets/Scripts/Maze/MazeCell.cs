using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject leftWall;

    public bool leftDestroyed = false;

    [SerializeField]
    private GameObject rightWall;

    public bool rightDestroyed = false;

    [SerializeField]
    private GameObject frontWall;

    public bool frontDestroyed = false;

    [SerializeField]
    private GameObject backWall;

    public bool backDestroyed = false;

    public bool Visited { get; private set; }

    public void VisitCell()
    {
        Visited = true;
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
