using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMetrics : MonoBehaviour
{
    private int shotsFired = 0;
    private int shotsHit = 0;
    // public double hitMissRatio;

    double hitMissRatio() {
        return (double)shotsHit/shotsFired;
    }

    public void incrementShotsFired() {
        shotsFired += 1;
    }

    public void incrementShotsHit() {
        shotsHit += 1;
    }
}
