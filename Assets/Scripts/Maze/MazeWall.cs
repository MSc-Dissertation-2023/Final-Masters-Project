using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWall : MonoBehaviour
{
    void Destroy()
    {
        gameObject.SetActive(false);
    }
}
