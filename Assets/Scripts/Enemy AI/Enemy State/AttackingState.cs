using System.Collections;
using UnityEngine;

public class AttackingState : EnemyState
{
    bool isAttacking = false;
		bool isDamaging = false;

    public AttackingState(Enemy enemy) : base(enemy) { }

    void Start()
    {
    }

    public override void Update()
    {
			if (!isAttacking ) {
				Ray ray = new Ray(enemy.transform.position, enemy.transform.forward);
				bool sphereColliding = Physics.SphereCast(ray, enemy.attackingRange, out RaycastHit hit);
				PlayerCharacter playerCharacter = hit.transform.GetComponent<PlayerCharacter>();
				if (sphereColliding && playerCharacter != null) {
					enemy.StartCoroutine(Attack());
				}	else {
					Debug.Log("Transition to chasing");
					enemy.ChangeState(new ChasingState(enemy));
				}
			}
    }

    private IEnumerator Attack()
    {
			isAttacking = true;
			animator.SetBool("Attacking", true);
			// soundSource.PlayOneShot(attackSound);

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
			isAttacking = false;
    }
}
