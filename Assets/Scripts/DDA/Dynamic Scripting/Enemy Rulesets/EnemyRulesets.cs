using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRulesets : MonoBehaviour
{
	public List<EnemyRule> rulesets;
	SceneController scene;

	void Start()
	{
		rulesets = new List<EnemyRule>();

		rulesets.Add(new EnemyRule(1.0f, IncreaseEnemyDamage, "enemyDamage"));
		rulesets.Add(new EnemyRule(1.0f, DecreaseEnemyDamage, "enemyDamage"));
		rulesets.Add(new EnemyRule(1.0f, IncreaseEnemySpeed, "enemySpeed"));
		rulesets.Add(new EnemyRule(1.0f, DecreaseEnemySpeed, "enemySpeed"));
		rulesets.Add(new EnemyRule(0.0f, IncreaseEnemyDodging, "enemyDodging"));
		rulesets.Add(new EnemyRule(0.0f, DecreaseEnemyDodging, "enemyDodging"));

		scene = GameObject.Find("Controller").GetComponent<SceneController>();
	}


}
