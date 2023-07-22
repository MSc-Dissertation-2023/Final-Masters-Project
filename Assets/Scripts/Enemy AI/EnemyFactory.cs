using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    public float damage = 15.0f;
    public float speedToAngularSpeedRatio = 70.0f;
    public float speed = 5.0f;
    public int enemiesCreated = 0;

    public static EnemyFactory Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public GameObject CreateEnemy(Vector3 location, Quaternion rotation)
    {
        enemiesCreated += 1;
        GameObject newEnemy = Instantiate(enemyPrefab, location, rotation);
        Enemy enemyComponent = newEnemy.GetComponent<Enemy>();

        enemyComponent.setDamage(damage);
        enemyComponent.speed = speed;
        enemyComponent.spawnLocation = location;

        float angularSpeed = speed * speedToAngularSpeedRatio;
        enemyComponent.agent.angularSpeed = speed * speedToAngularSpeedRatio;

        return newEnemy;
    }

}
