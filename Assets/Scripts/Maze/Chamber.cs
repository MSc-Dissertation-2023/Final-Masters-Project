using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamber
{
    private int width;
    private int height;
    private float xPos;
    private float yPos;

    private float size;

    public Chamber(int width, int height, float xPos,float yPos)
    {
        this.width = width;
        this.height = height;
        this.xPos = xPos;
        this.yPos = yPos;

        size = width * height;
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetXPos()
    {
        return xPos;
    }

    public float GetYPos()
    {
        return yPos;
    }

    public float GetSize()
    {
        return size;
    }
   
}
