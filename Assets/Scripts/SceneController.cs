using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class which controls spawning of enemies at random locations
 */
public class SceneController : MonoBehaviour
{
  [SerializeField] GameObject enemyPrefab;
  //Array of enemies
  public List<GameObject> enemies;
  EnemyMetrics enemyMetrics;
  private int numberOfEnemies = 3;

  private List<SpawnLocation> spawnLocations = new List<SpawnLocation>()
    {
        new SpawnLocation(new Vector3(11f, 1.5f, -30.5f), Quaternion.Euler(0, 0, 0)),
        new SpawnLocation(new Vector3(-30.5f, 1.5f, -6.5f), Quaternion.Euler(0, 90, 0)),
        new SpawnLocation(new Vector3(-21f, 1.5f, 30.5f), Quaternion.Euler(0, 180, 0)),
        new SpawnLocation(new Vector3(24f, 1.5f, 30.5f), Quaternion.Euler(0, 270, 0)),
        new SpawnLocation(new Vector3(30.5f, 1.5f, 9.5f), Quaternion.Euler(0, 0, 0))
    };

  void Start()
  {
    Managers.Player.OnSceneLoaded();
    Managers.Mission.LoadPlayerPrefs();
    enemyMetrics = GameObject.Find("Enemy Metrics").GetComponent<EnemyMetrics>();

    enemies = new List<GameObject>();

    for (int i = 0; i < numberOfEnemies; i++)
    {
      enemies.Add(null);
    }
  }

  void Update()
  {
    if(numberOfEnemies > enemies.Count) {
      for (int i = 0; i < numberOfEnemies - enemies.Count; i++) {
        enemies.Add(null);
      }
    }

    // Debug.Log($"Number of Enemies: {numberOfEnemies}, Enemies Count: {enemies.Count}");
    for (int i = 0; i < numberOfEnemies; i++)
    {
      //If any are dead
      if (numberOfEnemies == enemies.Count && enemies[i] == null)
      {
        //Spawn at random location
        int spawnLocation = DetermineSpawnLocation();

        enemies[i] = EnemyFactory.Instance.CreateEnemy(spawnLocations[spawnLocation].Location, spawnLocations[spawnLocation].Rotation);
      }
    }
  }

  private int DetermineSpawnLocation()
  {
    return Random.Range(1, 6) - 1;
  }


  public void setEnemyCount(int number)
  {
    numberOfEnemies = number;
  }

  public int getEnemyCount()
  {
    return numberOfEnemies;
  }

  public void IncreaseEnemyCount()
  {
    numberOfEnemies += 1;
  }

  public void DecreaseEnemyCount()
  {
    numberOfEnemies -= 1;
  }

  public void AddLiveEnemyStats() {
    enemyMetrics.liveEnemyStats = new List<EnemyStat>();
    for (int i = 0; i < numberOfEnemies; i++)
    {
      if (enemies[i] != null)
      {
        Enemy enemyScript = enemies[i].GetComponent<Enemy>();
        enemyMetrics.addLiveEnemyStats(enemyScript.StartDistanceToPlayer(), enemyScript.DistanceToPlayer(), enemyScript.speed, enemyScript.GetDamage());
      }
    }
  }
}

public struct SpawnLocation
{
  public Vector3 Location { get; }
  public Quaternion Rotation { get; }

  public SpawnLocation(Vector3 location, Quaternion rotation)
  {
    Location = location;
    Rotation = rotation;
  }
}
