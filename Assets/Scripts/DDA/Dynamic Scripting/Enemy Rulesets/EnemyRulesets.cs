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

		rulesets.Add(new EnemyRule(0.5f, "IncreaseEnemyDamage", "increase"));
		rulesets.Add(new EnemyRule(0.5f, "DecreaseEnemyDamage", "decrease"));
		rulesets.Add(new EnemyRule(0.5f, "IncreaseEnemySpeed", "increase"));
		rulesets.Add(new EnemyRule(0.5f, "DecreaseEnemySpeed", "decrease"));
		// rulesets.Add(new EnemyRule(0.0f, "IncreaseEnemyDodging", "enemyDodging"));
		// rulesets.Add(new EnemyRule(0.0f, "DecreaseEnemyDodging", "enemyDodging"));

		scene = GameObject.Find("Controller").GetComponent<SceneController>();
	}


}
