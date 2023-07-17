using System.Collections;
using UnityEngine;

public class ChasingState : EnemyState
{

    public ChasingState(Enemy enemy) : base(enemy) { }

    public override void Update()
    {
        if (!enemy.isAlive) return;

        agent.SetDestination(player.transform.position);
        animator.SetBool("Walking", true);

        BoxCollider collider = enemy.GetComponent<BoxCollider>();
        Vector3 size = Vector3.Scale(collider.size, enemy.transform.localScale);

        bool boxColliding = Physics.BoxCast(
            enemy.transform.position,
            size / 2,
            enemy.transform.forward,
            out RaycastHit hitInfo,
            Quaternion.identity,
            enemy.attackingRange
        );

        if (boxColliding)
        {
            PlayerCharacter playerCharacter = hitInfo.transform.GetComponent<PlayerCharacter>();

            if (playerCharacter != null && hitInfo.distance < enemy.attackingRange)
            {
                // Debug.Log("Transitioned to attacking");
                animator.SetBool("Walking", false);
                enemy.ChangeState(new AttackingState(enemy));
            }
        }
    }


}