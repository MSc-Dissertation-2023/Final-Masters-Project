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
    private GameObject[] enemies;
    //Define total number of enemies
    public int numberOfEnemies;
    //Spawn locations
    private Vector3 spawnOne;
    private Vector3 spawnTwo;

    void Start()
    {
        //Create vectors for spawn locations
        spawnOne = new Vector3(-5.5f, 1.5f, 39f);
        spawnTwo = new Vector3(44.5f, 1.5f, -19f);
        //Define the array of enemies
        enemies = new GameObject[numberOfEnemies];
    }

    void Update()
    {
        //Itterate through the array of enemies
        for (int i = 0; i < numberOfEnemies; i++)
        {
            //If any are dead
            if (enemies[i] == null)
            {
                //Create new enemy
                enemies[i] = Instantiate(enemyPrefab) as GameObject;

                //Spawn at random location
                int spawn = Random.Range(1, 3);
                if (spawn == 1)
                {
                    enemies[i].transform.position = spawnOne;
                }
                else
                {
                    enemies[i].transform.position = spawnTwo;
                }
                float angle = Random.Range(0, 360);
                enemies[i].transform.Rotate(0, angle, 0);

            }
        }
    }
}

