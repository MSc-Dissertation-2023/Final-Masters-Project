using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene
{
    private bool leftWall;
    private bool rightWall;
    private bool topWall;
    private bool bottomWall;
    private bool isVisited;

    private int genotype;

    public Gene(int genotype)
    {
        this.genotype = genotype;
        isVisited = false;
        
        switch (genotype)
        {
            case 0:
                leftWall = true;
                rightWall = true;
                topWall = true;
                bottomWall = false;
                break;
            case 1:
                leftWall = true;
                rightWall = false;
                topWall = true;
                bottomWall = true;
                break;
            case 2:
                leftWall = true;
                rightWall = true;
                topWall = false;
                bottomWall = true;
                break;
            case 3:
                leftWall = false;
                rightWall = true;
                topWall = true;
                bottomWall = true;
                break;
            case 4:
                leftWall = true;
                rightWall = false;
                topWall = true;
                bottomWall = false;
                break;
            case 5:
                leftWall = false;
                rightWall = true;
                topWall = true;
                bottomWall = false;
                break;
            case 6:
                leftWall = true;
                rightWall = false;
                topWall = false;
                bottomWall = true;
                break;
            case 7:
                leftWall = false;
                rightWall = true;
                topWall = false;
                bottomWall = true;
                break;
            case 8:
                leftWall = true;
                rightWall = true;
                topWall = false;
                bottomWall = false;
                break;
            case 9:
                leftWall = false;
                rightWall = false;
                topWall = true;
                bottomWall = true;
                break;
            case 10:
                leftWall = true;
                rightWall = false;
                topWall = false;
                bottomWall = false;
                break;
            case 11:
                leftWall = false;
                rightWall = false;
                topWall = true;
                bottomWall = false;
                break;
            case 12:
                leftWall = false;
                rightWall = true;
                topWall = false;
                bottomWall = false;
                break;
            case 13:
                leftWall = false;
                rightWall = false;
                topWall = false;
                bottomWall = true;
                break;
        }
    }

    public bool hasLeftWall() { return leftWall; }
    
    public bool hasRightWall() { return rightWall; }
    
    public bool hasFrontWall() { return topWall; }
    
    public bool hasBackWall() { return bottomWall; }

    public int getGenotype() { return genotype; }

    public bool IsVisited() { return isVisited; }

    public void visitCell()
    {
        isVisited = true;
    }
}
