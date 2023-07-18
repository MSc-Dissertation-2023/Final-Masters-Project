using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCountMetrics : MonoBehaviour
{
    private int killCount = 0;
    private int maxKillCount = 300;

    public void incrementKillCount() {
        killCount += 1;
    }

    public int getKillCount() {
        return killCount / maxKillCount;
    }
}
