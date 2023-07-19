using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMetrics : MonoBehaviour
{
    public SceneController scene;
    public float enemyMetrics = 0.0f;
    private List<EnemyStat> deadEnemyStats = new List<EnemyStat>();

    public List<EnemyStat> liveEnemyStats = new List<EnemyStat>();

    public List<EnemyStat> allEnemyStats = new List<EnemyStat>();

    void Start()
    {
        scene = GameObject.Find("Controller").GetComponent<SceneController>();
    }

    void CalculateEnemyMetrics() {
        scene.AddLiveEnemyStats();
        allEnemyStats.AddRange(deadEnemyStats);
        allEnemyStats.AddRange(liveEnemyStats);

        float sum = 0;

        foreach(EnemyStat stat in allEnemyStats) {
            sum += (1/(2.0f*allEnemyStats.Count) * (1 + (1 - (Mathf.Min(stat.StartDistance, stat.EndDistance)/stat.StartDistance))));
        }

        enemyMetrics = sum * (allEnemyStats.Count/50.0f);
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
        CalculateEnemyMetrics();
        return enemyMetrics;
    }

    public void addEnemyStats(float startDistance, float endDistance, float speed, float damage) {
        deadEnemyStats.Add(new EnemyStat(startDistance, endDistance, speed, damage));
    }

    public void addLiveEnemyStats(float startDistance, float endDistance, float speed, float damage) {
        liveEnemyStats.Add(new EnemyStat(startDistance, endDistance, speed, damage));
    }
}


public struct EnemyStat
{
  public float StartDistance { get; }
  public float EndDistance { get; }
  public float Speed { get; }
  public float Damage { get; }

  public EnemyStat(float startDistance, float endDistance, float speed, float damage)
  {
    StartDistance = startDistance;
    EndDistance = endDistance;
    Speed = speed;
    Damage = damage;
  }
}