using System.Collections;
using UnityEngine;

public class ChasingState : EnemyState
{

    public ChasingState(Enemy enemy) : base(enemy) { }

    public override void Update()
    {
        agent.SetDestination(player.transform.position);
        animator.SetBool("Walking", true);

        Ray ray = new Ray(enemy.transform.position, enemy.transform.forward);
        if (Physics.SphereCast(ray, enemy.attackingRange, out RaycastHit hit))
        {
            PlayerCharacter playerCharacter = hit.transform.GetComponent<PlayerCharacter>();

            if (playerCharacter != null && hit.distance < enemy.attackingRange)
            {
                animator.SetBool("Walking", false);
                enemy.ChangeState(new AttackingState(enemy));
            }
        }
    }


}