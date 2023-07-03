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
		navMesh.enabled = false;

		enemy.GetComponent<BoxCollider>().enabled = false;

		yield return new WaitForSeconds(3.0f);
		UnityEngine.Object.Destroy(enemy.gameObject);
	}
}
