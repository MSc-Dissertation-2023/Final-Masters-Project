using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMetrics : MonoBehaviour
{
    private float totalDamageTaken = 0;
    public float getTotalDamageTaken => totalDamageTaken;

    public void RegisterDamageTaken(float amount) {
        totalDamageTaken += amount;
    }
}
