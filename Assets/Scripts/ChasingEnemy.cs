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

    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip attackSound;
    [SerializeField] AudioClip moanSound1;
    [SerializeField] AudioClip moanSound2;
    [SerializeField] AudioClip moanSound3;

    private GameObject player;
    private NavMeshAgent agent;
    private bool playerLocked;

    private Animator animator;

    void Start()
    {
        isAlive = true;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerLocked = true;
        soundSource = GetComponent<AudioSource>();
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
                // RaycastHit hit;
                if (Physics.SphereCast(ray, 2.0f, out RaycastHit hit))
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

            if (!soundSource.isPlaying)
            {
                int randomZombieNoise = Random.Range(1, 10000);
                switch (randomZombieNoise)
                {
                    case 199:
                        soundSource.PlayOneShot(moanSound1);
                        break;
                    case 299:
                        soundSource.PlayOneShot(moanSound2);
                        break;
                    case 399:
                        soundSource.PlayOneShot(moanSound3);
                        break;

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
        soundSource.PlayOneShot(attackSound);
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
