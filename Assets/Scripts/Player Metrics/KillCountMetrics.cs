using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCountMetrics : MonoBehaviour
{
    private int killCount = 0;
    private int maxKillCount = 30;

    public void incrementKillCount() {
        killCount += 1;
    }

    public float getKillCount() {
        return (float)killCount / maxKillCount;
    }
}
