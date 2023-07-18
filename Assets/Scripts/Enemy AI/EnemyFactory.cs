using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    public float damage = 15.0f;
    public float speed = 5.0f;

    public static EnemyFactory Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public GameObject CreateEnemy(Vector3 location, Quaternion rotation)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, location, rotation);
        Enemy enemyComponent = newEnemy.GetComponent<Enemy>();

        enemyComponent.setDamage(damage);
        enemyComponent.speed = speed;
        return newEnemy;
    }

}
