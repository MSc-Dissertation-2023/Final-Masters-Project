using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Makes enemies dies once hit
 */
public class TargetEnemy : MonoBehaviour
{
    public int health;
    public Rigidbody rigidbody;
    private Animator animator;
    public GameObject healthPickupPrefab;


    void Start()
    {
        //Default health value
        health = 100;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        //Diable rigid body while alive
        rigidbody.isKinematic = true;

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
    public void ReactToHit()
    {
        health -= 25;
    }

    //Rotated killed emenies who then dissapear into the ground and the destroys them
    private IEnumerator Die()
    {
        animator.SetBool("Dying", true);

        //Remove NavMesh
        UnityEngine.AI.NavMeshAgent navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Destroy(navMesh);
        //Enable ridig body and remove collider so that enemies fall into the ground
        //rigidbody.isKinematic = false;
        GetComponent<Collider>().enabled = false;

        // Instantiate a health pickup at this enemy's position
        Instantiate(healthPickupPrefab, transform.position, Quaternion.identity);

        /*/Rotate as they fall
        for (int i = 0; i < 5; i++)
        {
            this.transform.Rotate(-18, 0, 0);
            yield return new WaitForSeconds(0.2f);
        }*/
        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
    }
}
