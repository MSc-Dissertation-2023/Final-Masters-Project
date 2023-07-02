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

		yield return new WaitForSeconds(4.0f);
		UnityEngine.Object.Destroy(enemy.gameObject);
	}
}
