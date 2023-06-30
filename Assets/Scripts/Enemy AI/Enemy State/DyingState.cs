using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DyingState : EnemyState
{
	public DyingState(Enemy enemy) : base(enemy)
	{
	}

	// Update is called once per frame
	public override void Update()
	{
		enemy.StartCoroutine(Die());
	}

	private IEnumerator Die() {
		animator.SetBool("Dying", true);

		//Remove NavMesh
		UnityEngine.AI.NavMeshAgent navMesh = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
		UnityEngine.Object.Destroy(navMesh);

		enemy.GetComponent<Collider>().enabled = false;

		var enemyPos = enemy.transform.position;
		var enemyDropsPos = new Vector3(enemyPos.x, 2, enemyPos.z);

		float rand = Random.value; // Generates a random float between 0.0 and 1.0

		// if (rand < 0.3) // 30% chance
		// {
		// 		Instantiate(ammoPickupPrefab, enemyDropsPos, Quaternion.identity);
		// }
		// else if (rand < 0.6) // Additional 30% chance
		// {
		// 		Instantiate(healthPickupPrefab, enemyDropsPos, Quaternion.identity);
		// }
		// else if (rand < 0.75) // Additional 15% chance
		// {
		// 		Instantiate(damageUpgradePickupPrefab, enemyDropsPos, Quaternion.identity); // Assuming you have a damagePrefab
		// }
		// Else there is a 25% chance to do nothing (no drop)


		yield return new WaitForSeconds(4.0f);
		UnityEngine.Object.Destroy(enemy);
	}
}
