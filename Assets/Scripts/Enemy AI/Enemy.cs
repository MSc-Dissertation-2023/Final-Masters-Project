using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // private EnemyState currentState;
    public Animator animator;
    private EnemyState currentState;
    public float health = 100; // Health value of the enemy
    public int damage = 15; // Damage value of the enemy
    public NavMeshAgent agent;
    public GameObject player;
    public PlayerCharacter playerChar;
    public float attackingRange = 5.0f;

    private void Start()
    {
        // Initialize the starting state (e.g., ChasingState)
        player = GameObject.Find("Player");
        playerChar = player.GetComponent<PlayerCharacter>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        currentState = new ChasingState(this);
    }

    void Update()
    {
        // Delegate the Update behavior to the current state
        currentState.Update();

        if (health <= 0.0f) {
            ChangeState(new DyingState(this));
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
            ChangeState(new DyingState(this));
        }
    }
}
