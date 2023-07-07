using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMetrics : MonoBehaviour
{
    private int killCount = 0;

    public void incrementKillCount() {
        killCount += 1;
    }

    public int getKillCount() {
        return killCount;
    }
}
