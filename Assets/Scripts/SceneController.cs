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
    private List<GameObject> enemies;
    private int numberOfEnemies = 5;
    private EnemyRuleset enemyRuleset;
    private GameRuleset gameRuleset;

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
        enemies = new List<GameObject>();

        for (int i = 0; i < numberOfEnemies; i++)
        {
            enemies.Add(null);
        }
    }

    void Update()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            //If any are dead
            if (enemies[i] == null)
            {
                //Spawn at random location
                int spawnLocation = DetermineSpawnLocation();

                InstantiatePrefab(i, spawnLocations[spawnLocation].Location, spawnLocations[spawnLocation].Rotation);
            }
        }
    }

    private void InstantiatePrefab(int enemyID, Vector3 spawnLocation, Quaternion rotation) {
        GameObject enemy = Instantiate(enemyPrefab, spawnLocation, rotation);
        enemy.SetActive(false);

        if (enemyRuleset != null) {
            Enemy enemyScript = enemy.GetComponent<Enemy>();

            enemyRuleset.ApplyRules(enemyScript);
        }

        enemy.SetActive(true);
        enemies[enemyID] = enemy;
    }

    private int DetermineSpawnLocation() {
        if (gameRuleset == null) {
            return Random.Range(1, 6) - 1;
        } else {
            // gameRuleset.ApplyRules(spawnLocations, )
            return 0;
        }
    }


    public void setEnemyCount(int number) {
        numberOfEnemies = number;
    }

    public void IncreaseEnemyCount() {
        numberOfEnemies += 1;
    }

    public void DecreaseEnemyCount() {
        numberOfEnemies -= 1;
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
