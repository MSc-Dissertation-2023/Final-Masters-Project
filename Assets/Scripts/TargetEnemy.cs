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
    private UIController uiController;

    void Start()
    {
        //Default health value
        health = 100;

        animator = GetComponent<Animator>();
        uiController = GameObject.Find("UIController").GetComponent<UIController>();

    }

    void Update ()
    {
        //When hewlthe hits 0, enemy dies
        if (health <= 0)
        {
            health = 1;
            ChasingEnemy behavior = GetComponent<ChasingEnemy>();
            uiController.OnEnemyKilled();
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

        int rand = Random.Range(1, 3);

        if (rand == 1)
        {
            Instantiate(ammoPickupPrefab, enemyDropsPos, Quaternion.identity);
        } else
        {
            Instantiate(healthPickupPrefab, enemyDropsPos, Quaternion.identity);
        }

        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
    }
}
