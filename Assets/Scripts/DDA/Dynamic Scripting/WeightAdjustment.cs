using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightAdjustment : MonoBehaviour
{
    FitnessCalculator fitnessCalculator;
    EnemyRuleManager enemyRuleManager;
    GameRuleManager gameRuleManager;
    List<EnemyRule> enemyRulesets;
    List<EnemyRule> enemyRuleset;
    EnemyMetrics enemyMetrics;

    void Start()
    {
        enemyRuleManager = GetComponent<EnemyRuleManager>();
        gameRuleManager = GetComponent<GameRuleManager>();
        fitnessCalculator = GameObject.Find("Player Metrics").GetComponent<FitnessCalculator>();
        enemyMetrics = GameObject.Find("Enemy Metrics").GetComponent<EnemyMetrics>();

        InvokeRepeating("AdjustWeights", 18, 5);
        // InvokeRepeating("AdjustGameWeights", 15, 10);
    }

    void AdjustWeights() {
        enemyRuleset = enemyRuleManager.enemyRuleset.rulesets;
        enemyRulesets = enemyRuleManager.enemyRulesets.rulesets;

        int active = 0;

        foreach(EnemyRule rule in enemyRuleset) {
            active += 1;
        }

        if (active <= 0) {
            return;
        }

        int nonactive = enemyRulesets.Count - enemyRuleset.Count;

        float adjustment = CalculateAdjustment();

        float compensation = -active * adjustment / nonactive;

        float remainder = 0.0f;

        float minweight = 0.2f;

        float maxweight = 1.0f;

        foreach(EnemyRule rule in enemyRulesets) {
            if (enemyRuleset.Contains(rule)) {
                rule.weight = rule.weight + adjustment;
            } else {
                rule.weight = rule.weight + compensation;
            }

            if (rule.weight < minweight) {
                remainder = remainder + (rule.weight - minweight);
            } else if (rule.weight > maxweight) {
                remainder += (rule.weight - maxweight);
                rule.weight = maxweight;
            }
        }

        // DistributeRemainder();
    }

    // void AdjustEnemyWeights() {
    //     int active = 3; // TO BE CHANGED

    //     int nonactive = 3;
    //     double adjustment = CalculateAdjustment(fitnessCalculator.GetFitness());
    // }

    // void AdjustGameWeights() {

    // }

    private float CalculateAdjustment() {
        float playerFitness = fitnessCalculator.GetFitness();
        float enemyFitness = enemyMetrics.getFitness();
        float amount = 0.0f;

        if(playerFitness < enemyFitness) {
            amount = -0.2f*((enemyFitness-playerFitness)/enemyFitness);
        } else {
            amount = 0.2f*((playerFitness-enemyFitness)/(1-enemyFitness));
        }

        return amount;
    }
}
