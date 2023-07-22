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
        enemyFactory.speed += enemyFactory.speed * adjustment;
        enemyFactory.damage += enemyFactory.damage * adjustment;
        scene.setEnemyCount(Mathf.RoundToInt(scene.getEnemyCount() + (scene.getEnemyCount() * adjustment)));


        Debug.Log($"Adj: {adjustment}");
    }

    private float CalculateAdjustment() {
        float enemyFitness = enemyMetrics.getFitness();
        float playerFitness = fitnessCalculator.GetFitness();

        Debug.Log($"Enemy Fitness: {enemyFitness}, Player Fitness: {playerFitness}");

        float weightAdjustment = 0.0f;
        float threshold = 0.2f;

        float fitnessDifference = playerFitness - enemyFitness;

        if(Mathf.Abs(fitnessDifference) >= threshold) {
            weightAdjustment = ((playerFitness - threshold)/(1 - threshold));
        } else {
            weightAdjustment = threshold - playerFitness;
        }

        return weightAdjustment;
    }
}
