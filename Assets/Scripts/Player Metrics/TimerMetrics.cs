using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMetrics : MonoBehaviour
{
    private int timer = 0;
    private int maxTimer = 300;
    public int getTimer => Mathf.Min(timer, maxTimer)/maxTimer;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncrementTimer", 0, 1);
    }

    void IncrementTimer() {
        timer += 1;
    }
}
