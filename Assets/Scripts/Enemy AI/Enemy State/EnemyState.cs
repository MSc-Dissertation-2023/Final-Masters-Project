using UnityEngine;
using UnityEngine.AI;
public abstract class EnemyState : IEnemyState
{
    protected Enemy enemy;
    protected Animator animator;
    protected NavMeshAgent agent;
    protected GameObject player;
    protected PlayerManager playerManager;
    protected PlayerCharacter playerChar;

    public EnemyState(Enemy enemy)
    {
        this.enemy = enemy;
        this.animator = enemy.animator;
        this.agent = enemy.agent;
        this.player = enemy.player;
        this.playerManager = enemy.playerManager;
        this.playerChar = enemy.playerChar;
    }

    public virtual void Update() {

    }
}
