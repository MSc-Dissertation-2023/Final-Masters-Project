using System.Collections;
using UnityEngine;

public class AttackingState : EnemyState
{
    bool isAttacking = false;
		bool isDamaging = false;
		// for debugging purposess
		bool boxColliding = false;
		RaycastHit hitInfo;

    public AttackingState(Enemy enemy) : base(enemy) { }

    void Start()
    {
    }

    public override void Update()
    {
			if (!isAttacking ) {
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

				if (boxColliding && hitInfo.transform != null) {
					PlayerCharacter playerCharacter = hitInfo.transform.GetComponent<PlayerCharacter>();
					if(playerCharacter != null) {
						Debug.Log("Attack Coroutine");
						enemy.StartCoroutine(Attack());
					}
				}

				if (!isAttacking) {
					// Debug.Log("Transition to chasing");
					enemy.ChangeState(new ChasingState(enemy));
				}
			}
    }

    private IEnumerator Attack()
    {
			// Debug.Log("STarting Atk");
			if (isAttacking) yield break;
			isAttacking = true;
			agent.isStopped = true;
			animator.SetBool("Attacking", true);
			enemy.soundSource.PlayOneShot(enemy.attackSound);

			//keep facing the player & stop moving

			yield return new WaitForSeconds(0.812f);  // wait until 29th frame
			// stop facing the player and execute attack
			isDamaging = true;
			// start damaging the player
			if ((playerChar.transform.position - enemy.transform.position).magnitude <= enemy.attackingRange && isDamaging)
			{
					playerChar.Hurt(enemy.damage);
			}

			yield return new WaitForSeconds(0.14f);  // wait until 34th frame

			// stop damaging the player
			isDamaging = false;

			yield return new WaitForSeconds(2.18f - 0.812f - 0.14f);  // Remainder of the animation

			animator.SetBool("Attacking", false);
			agent.isStopped = false;
			isAttacking = false;
			// Debug.Log("End of ATk");
    }

		//Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this. For debugging purposes
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
				Debug.Log("Coloring");
        //Check if there has been a hit yet
        if (boxColliding)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(enemy.transform.position, enemy.transform.forward * hitInfo.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(enemy.transform.position + enemy.transform.forward * hitInfo.distance, enemy.transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(enemy.transform.position, enemy.transform.forward * enemy.attackingRange);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(enemy.transform.position + enemy.transform.forward * enemy.attackingRange, enemy.transform.localScale);
        }
    }
}
