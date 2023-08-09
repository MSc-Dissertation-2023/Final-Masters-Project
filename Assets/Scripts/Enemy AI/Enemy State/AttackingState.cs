using System.Collections;
using UnityEngine;

public class AttackingState : EnemyState
{
    bool isAttacking = false;
		bool isDamaging = false;
		// for debugging purposess
		RaycastHit hitInfo;

    public AttackingState(Enemy enemy) : base(enemy) { }


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
					enemy.AttackingRange
				);

				if (boxColliding && hitInfo.transform != null) {
					PlayerCharacter playerCharacter = hitInfo.transform.GetComponent<PlayerCharacter>();
					if(playerCharacter != null) {
						// Debug.Log("Attack Coroutine");
						attackRoutine = enemy.StartCoroutine(Attack());
						// enemy.StartCoroutine(Attack());
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
			if (playerIsInEnemyAttackRange(player, enemy) && isDamaging)
			{
				BoxCollider enemyObject = enemy.GetComponent<BoxCollider>();
				Vector3 direction = player.transform.position - enemyObject.transform.position;

				if (Vector3.Dot(enemyObject.transform.forward, direction.normalized) > 0f)
				{

					playerManager.ApplyDamage(enemy.GetDamage());
				}
			}

			yield return new WaitForSeconds(0.14f);  // wait until 34th frame

			// stop damaging the player
			isDamaging = false;

			yield return new WaitForSeconds(2.18f - 0.812f - 0.14f);  // Remainder of the animation

			animator.SetBool("Attacking", false);
			agent.isStopped = false;
			isAttacking = false;
    }

	private bool playerIsInEnemyAttackRange (GameObject player, Enemy enemy) {
		float magnitude = (player.transform.position - enemy.transform.position).magnitude;

		return magnitude <= enemy.AttackingRange;
	}
}
