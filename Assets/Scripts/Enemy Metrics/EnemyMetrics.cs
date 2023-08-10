using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

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

        float currentFitness = 0.0f;
        float previousFitness = 0.0f;

        foreach(EnemyStat stat in liveEnemyStats) {
            currentFitness += (liveEnemyStats.Count/40.0f) * (1/(2.0f *(liveEnemyStats.Count)) * (1 + (1 - (Mathf.Min(stat.StartDistance, stat.EndDistance)/stat.StartDistance))));
        }

        foreach(EnemyStat stat in deadEnemyStats) {
            previousFitness += (deadEnemyStats.Count/300.0f) * (1/(2.0f *(deadEnemyStats.Count)) * (1 + (1 - (Mathf.Min(stat.StartDistance, stat.EndDistance)/stat.StartDistance))));
        }

        previousFitness *= 0.1f;

        float sum = currentFitness + previousFitness;

        StartCoroutine(PostStatistics(sum, currentFitness, previousFitness, liveEnemyStats.Count, deadEnemyStats.Count));

        // Debug.Log($"Dead Enemies: {deadEnemyStats.Count}, Alive Enemies: {liveEnemyStats.Count}");
        enemyMetrics = sum ;
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

    IEnumerator PostStatistics(float totalFitness, float currentFitness, float previousFitness, int liveEnemiesCount, int deadEnemiesCount) {
        using (UnityWebRequest www = UnityWebRequest.Post(
            $"www.mdk2023.com/stage_two_enemy_metrics?total_fitness={totalFitness}&current_fitness={currentFitness}&previous_fitness={previousFitness}&live_enemies_count={liveEnemiesCount}&dead_enemies_count={deadEnemiesCount}", "", "application/json"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Post Enemy Metrics API Request complete!");
            }
        }
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