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
    private Vector3 spawnThree;
    private Vector3 spawnFour;
    private Vector3 spawnFive;

    void Start()
    {
        //Create vectors for spawn locations
        spawnOne = new Vector3(11f, 1.5f, -30.5f);
        spawnTwo = new Vector3(-30.5f, 1.5f, -6.5f);
        spawnThree = new Vector3(-21f, 1.5f, 30.5f);
        spawnFour = new Vector3(24f, 1.5f, 30.5f);
        spawnFive = new Vector3(30.5f, 1.5f, 9.5f);
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
             
                //Spawn at random location
                int spawn = Random.Range(1, 6);


                if (spawn == 1)
                {
                    Quaternion rotation = Quaternion.Euler(0, 0, 0);
                    enemies[i] = Instantiate(enemyPrefab, spawnOne, rotation);
                    
                }
                else if (spawn == 2)
                {
                    Quaternion rotation = Quaternion.Euler(0, 90, 0);
                    enemies[i] = Instantiate(enemyPrefab, spawnTwo, rotation);
                    
                }
                else if (spawn == 3)
                {
                    Quaternion rotation = Quaternion.Euler(0, 180, 0);
                    enemies[i] = Instantiate(enemyPrefab, spawnThree, rotation);
                    
                }
                else if (spawn == 4)
                {
                    Quaternion rotation = Quaternion.Euler(0, 180, 0);
                    enemies[i] = Instantiate(enemyPrefab, spawnFour, rotation);
                    
                }
                else
                {
                    Quaternion rotation = Quaternion.Euler(0, 270, 0);
                    enemies[i] = Instantiate(enemyPrefab, spawnFive, rotation);
                    
                }

            }
        }
    }
}

