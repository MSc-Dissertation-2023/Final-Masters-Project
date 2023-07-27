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
                SetPhenotype(true, true, true, false);
                break;
            case 1:
                SetPhenotype(true, false, true, true);
                break;
            case 2:
                SetPhenotype(true, true, false, true);
                break;
            case 3:
                SetPhenotype(false, true, true, true);
                break;
            case 4:
                SetPhenotype(true, false, true, false);
                break;
            case 5:
                SetPhenotype(false, true, true, false);
                break;
            case 6:
                SetPhenotype(true, false, false, true);
                break;
            case 7:
                SetPhenotype(false, true, false, true);
                break;
            case 8:
                SetPhenotype(true, true, false, false);
                break;
            case 9:
                SetPhenotype(false, false, true, true);
                break;
            case 10:
                SetPhenotype(true, false, false, false);
                break;
            case 11:
                SetPhenotype(false, false, true, false);
                break;
            case 12:
                SetPhenotype(false, true, false, false);
                break;
            case 13:
                SetPhenotype(false, false, false, true);
                break;
        }
    }

    private void SetPhenotype(bool leftWall, bool rightWall, bool topWall, bool bottomWall)
    {
        this.leftWall = leftWall;
        this.rightWall = rightWall;
        this.topWall = topWall;
        this.bottomWall = bottomWall;
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
