using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightAdjustment : MonoBehaviour
{
    FitnessCalculator fitnessCalculator;
    EnemyRuleManager enemyRuleManager;
    GameRuleManager gameRuleManager;

    void Start()
    {
        enemyRuleManager = GetComponent<EnemyRuleManager>();
        gameRuleManager = GetComponent<GameRuleManager>();
        fitnessCalculator = GameObject.Find("Player Metrics").GetComponent<FitnessCalculator>();
        InvokeRepeating("AdjustWeights", 15, 10);
        // InvokeRepeating("AdjustGameWeights", 15, 10);
    }

    void AdjustWeights() {

    }

    void AdjustEnemyWeights() {
        int active = 3; // TO BE CHANGED

        int nonactive = 3;
        double adjustment = CalculateAdjustment(fitnessCalculator.GetFitness());
    }

    void AdjustGameWeights() {

    }

    private double CalculateAdjustment(double fitness) {
        return 0.0;
    }
}
