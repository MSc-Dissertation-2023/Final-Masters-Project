using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMetrics : MonoBehaviour
{
    public SceneController scene;
    public float enemyMetrics = 0.0f;

    void Start()
    {
        scene = GameObject.Find("Controller").GetComponent<SceneController>();

        InvokeRepeating("CalculateEnemyMetrics", 5, 2);
    }

    void CalculateEnemyMetrics() {
        int maxValue = 4000;
        int minValue = 0;

        enemyMetrics = numberOfEnemies() + 0.4f * averageMetricofEnemy();

        // normalize values between 0 and 1
        enemyMetrics = (enemyMetrics - minValue) / (maxValue - minValue);
    }

    int numberOfEnemies() {
        return scene.enemies.Count;
    }

    float averageMetricofEnemy() {
        float totalScore = 0;
        foreach (GameObject enemyGameObject in scene.enemies) {
            Enemy enemy = enemyGameObject.GetComponent<Enemy>();
            totalScore += score(enemy);
        }
        return scene.enemies.Count > 0 ? totalScore / scene.enemies.Count : 0;
    }

    float score(Enemy enemy) {
        return 0.8f * enemy.speed + 0.5f * enemy.GetDamage() + 0.4f * (-1.0f * enemy.DistanceToPlayer());
    }

    public float getFitness() {
        return enemyMetrics;
    }
}