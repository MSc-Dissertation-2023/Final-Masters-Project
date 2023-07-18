using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // private EnemyState currentState;
    public Animator animator;
    private EnemyState currentState;
    public float health = 100.0f; // Health value of the enemy
    private float damage = 15.0f; // Damage value of the enemy
    public NavMeshAgent agent;
    public GameObject player;
    public PlayerCharacter playerChar;
    KillCountMetrics killMetrics;
    public GameObject healthPickupPrefab;
    public GameObject ammoPickupPrefab;
    public GameObject damageUpgradePickupPrefab;
    public float attackingRange = 2.0f;
    public float speed = 5.0f;
    public bool isAlive = true;

    [SerializeField] public AudioSource soundSource;
    [SerializeField] public AudioClip attackSound;
    [SerializeField] public AudioClip moanSound1;
    [SerializeField] public AudioClip moanSound2;
    [SerializeField] public AudioClip moanSound3;

    private void Start()
    {
        // For scene 2 only
        if(GameObject.Find("Player Metrics") != null) { killMetrics = GameObject.Find("Player Metrics").GetComponent<KillCountMetrics>(); }

        player = GameObject.FindWithTag("Player");
        playerChar = player.GetComponent<PlayerCharacter>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.autoBraking = true;
        soundSource = GetComponent<AudioSource>();
        currentState = new ChasingState(this);
    }

    // needed for DDA
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Delegate the Update behavior to the current state
        currentState.Update();

        if (health <= 0.0f) {
            ChangeState(new DyingState(this));
        } else if (!soundSource.isPlaying) {
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

     public void ChangeState(EnemyState newState)
    {
        currentState = newState;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        // Immediate death check, in case damage was taken outside of Update() loop
        if (health <= 0.0f)
        {
            if(currentState.attackRoutine != null) {
                StopCoroutine(currentState.attackRoutine);
            }

		    GameEvents.NotifyDeath();
            if(killMetrics != null) { killMetrics.incrementKillCount(); }
            InstantiateCollectibleItems();
            ChangeState(new DyingState(this));
        }
    }

    public void InstantiateCollectibleItems() {
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

    }

    public void setDamage(float newDamageValue) {
        damage = newDamageValue;
    }

    public float GetDamage() {
        return damage;
    }

    public void setSpeed(float newSpeed) {
        speed = newSpeed;
        agent.speed = speed;
    }

    public float DistanceToPlayer() {
        return Vector3.Distance(transform.position, player.transform.position);
    }


}
