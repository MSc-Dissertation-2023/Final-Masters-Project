using UnityEngine;
using UnityEngine.AI;
public abstract class EnemyState : IEnemyState
{
    protected Enemy enemy;
    protected Animator animator;
    protected NavMeshAgent agent;
    protected GameObject player;
    protected PlayerCharacter playerChar;
    public Coroutine attackRoutine;

    public EnemyState(Enemy enemy)
    {
        this.enemy = enemy;
        this.animator = enemy.animator;
        this.agent = enemy.agent;
        this.player = enemy.player;
        this.playerChar = enemy.playerChar;
    }

    public virtual void Update() {

    }
}
