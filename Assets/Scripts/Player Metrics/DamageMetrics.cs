using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMetrics : MonoBehaviour
{
    private float totalDamageTaken = 0;
    public float getTotalDamageTaken => totalDamageTaken;
    private int hitsTakenCount = 0;
    private int maxHitsTaken = 50;
    public float getHitsTaken => getHitsTakenCount();

    public void RegisterDamageTaken(float amount) {
        totalDamageTaken += amount;
    }

    public void incrementHitsTaken() {
        hitsTakenCount += 1;
    }

    public int getHitsTakenCount() {
        return Mathf.Min(hitsTakenCount) / maxHitsTaken;
    }
}
