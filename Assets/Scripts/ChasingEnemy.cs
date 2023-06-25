using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingEnemy : MonoBehaviour
{
    //Set speed of AI
    public float speed = 1.0f;
    //Range of obstacle detection
    public float obstacleRange = 5.0f;
    public float attackingRange = 1.0f;
    private bool isAlive;
    public float enemyDamage = 15.0f;

    private GameObject player;
    private NavMeshAgent agent;
    private bool playerLocked;

    private Animator animator;

    void Start()
    {
        isAlive = true;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 5.0f;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerLocked = true;
    }

    void Update()
    {
        if (isAlive) 
        {
            //If player in not locked onto move forward until an obstacle detected.
            if (!playerLocked)
            {
                //Move forward reative to speed
                transform.Translate(0, 0, speed * Time.deltaTime);
                animator.SetBool("Walking", true);
                

                //Send ray directly infront of AI
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                //If an Object is detected in sphere cast
                if (Physics.SphereCast(ray, 2.0f, out hit))
                {
                    //Get game object
                    GameObject hitObject = hit.transform.gameObject;
                    //If object is a player lock onto player
                    if (hitObject.GetComponent<PlayerCharacter>())
                    {
                        player = hitObject;
                        playerLocked = true;
                    }
                    //Else turn randomly in a radus
                    if (hit.distance < obstacleRange)
                    {
                        
                        float angle = Random.Range(-110, 110);
                        transform.Rotate(0, angle, 0);
                    }

                }
            }
            //If locked to player use NavMesh pathfinding
            else
            {
                agent.SetDestination(player.transform.position);
                animator.SetBool("Walking", true);
                

                //Send ray directly infront of AI
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if (Physics.SphereCast(ray, 2.0f, out hit))
                {
                    //Get game object
                    GameObject hitObject = hit.transform.gameObject;
                    PlayerCharacter playerCharacter = hitObject.GetComponent<PlayerCharacter>();
                    //If object is a player lock onto player
                    if (playerCharacter != null)
                    {
                        if (hit.distance < attackingRange)
                        {
                           
                            StartCoroutine(Attack(playerCharacter, hit));
                        }
                    }
                }
            }

        }
    }

    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }

    private IEnumerator Attack(PlayerCharacter playerChar, RaycastHit hit)
    {
        this.enabled = false;

        animator.SetBool("Walking", false);
        animator.SetBool("Attacking", true);

        yield return new WaitForSeconds(1);

        //GameObject hitObject = hit.transform.gameObject;
        if (hit.distance <= attackingRange)
        {
            playerChar.Hurt(enemyDamage);
        }
        
        yield return new WaitForSeconds(1);

        animator.SetBool("Attacking", false);
        this.enabled = true;
        
    }
}
