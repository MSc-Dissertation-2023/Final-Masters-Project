using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDifficultyAdjustment : MonoBehaviour
{
    EnemyFactory enemyFactory;
    FitnessCalculator fitnessCalculator;
    EnemyMetrics enemyMetrics;
    SceneController scene;

    // Start is called before the first frame update
    void Start()
    {
        enemyFactory = GameObject.Find("Enemy Factory").GetComponent<EnemyFactory>();
        fitnessCalculator = GameObject.Find("Player Metrics").GetComponent<FitnessCalculator>();
        enemyMetrics = GameObject.Find("Enemy Metrics").GetComponent<EnemyMetrics>();
        scene = GameObject.Find("Controller").GetComponent<SceneController>();
        InvokeRepeating("AdjustDifficulty", 5, 5);
    }

    void AdjustDifficulty() {
        float adjustment = CalculateAdjustment();
        int newEnemyCount = Mathf.RoundToInt(scene.getEnemyCount() + (scene.getEnemyCount() * adjustment));
        // Debug.Log(newEnemyCount)
        scene.setEnemyCount(newEnemyCount);
    }

    private float CalculateAdjustment() {
        float enemyFitness = enemyMetrics.getFitness();
        float playerFitness = fitnessCalculator.GetFitness();

        float weightAdjustment = 0.0f;
        float threshold = 0.15f;

        float fitnessDifference = playerFitness - enemyFitness;

        if(Mathf.Abs(fitnessDifference) > threshold) {
            if (fitnessDifference > 0) {
                // Player fitness is higher than enemy's
                weightAdjustment = ((playerFitness - threshold)/(1 - threshold));
            } else {
                // Player fitness is lower than enemy's
                weightAdjustment = threshold - playerFitness;
            }
        }

        // Debug.Log($"Enemy Fit: {enemyFitness}, Player Fit: {playerFitness}, Adj: {weightAdjustment}");

        return weightAdjustment;
    }
}
