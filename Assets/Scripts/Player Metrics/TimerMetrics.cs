using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMetrics : MonoBehaviour
{
    private int timer = 0;
    public int getTimer => timer;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncrementTimer", 0, 1);
    }

    void IncrementTimer() {
        timer += 1;
    }
}
