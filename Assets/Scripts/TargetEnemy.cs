using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Makes enemies dies once hit
 */
public class TargetEnemy : MonoBehaviour
{
    public int health;
    private Animator animator;
    public GameObject healthPickupPrefab;
    public GameObject ammoPickupPrefab;
    public GameObject damageUpgradePickupPrefab;

    void Start()
    {
        //Default health value
        health = 100;

        animator = GetComponent<Animator>();

    }

    void Update ()
    {
        //When hewlthe hits 0, enemy dies
        if (health <= 0)
        {
            health = 1;
            ChasingEnemy behavior = GetComponent<ChasingEnemy>();
            Messenger.Broadcast(GameEvent.ENEMY_KILLED);
            if (behavior != null)
            {
                behavior.SetAlive(false);
            }
            StartCoroutine(Die());
        }
    }

    //Take health when hit
    public void ReactToHit(int damage)
    {
        health -= damage;
    }

    //Rotated killed emenies who then dissapear into the ground and the destroys them
    private IEnumerator Die()
    {
        animator.SetBool("Dying", true);

        //Remove NavMesh
        UnityEngine.AI.NavMeshAgent navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Destroy(navMesh);

        GetComponent<Collider>().enabled = false;

        var enemyPos = transform.position;
        var enemyDropsPos = new Vector3(enemyPos.x, 2, enemyPos.z);

        float rand = Random.value; // Generates a random float between 0.0 and 1.0

        if (rand < 0.3) // 30% chance
        {
            Instantiate(ammoPickupPrefab, enemyDropsPos, Quaternion.identity);
        }
        else if (rand < 0.6) // Additional 30% chance
        {
            Instantiate(healthPickupPrefab, enemyDropsPos, Quaternion.identity);
        }
        else if (rand < 0.75) // Additional 15% chance
        {
            Instantiate(damageUpgradePickupPrefab, enemyDropsPos, Quaternion.identity); // Assuming you have a damagePrefab
        }
        // Else there is a 25% chance to do nothing (no drop)


        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
    }
}
