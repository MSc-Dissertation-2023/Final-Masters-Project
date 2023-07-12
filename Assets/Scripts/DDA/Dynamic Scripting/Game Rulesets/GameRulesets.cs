using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRulesets : MonoBehaviour
{
	public List<GameRule> rulesets;
	SceneController scene;

	void Start()
	{
		rulesets = new List<GameRule>();

		rulesets.Add(new GameRule(1.0f, "IncreaseEnemyCount", "enemyCount"));
		rulesets.Add(new GameRule(1.0f, "DecreaseEnemyCount", "enemyCount"));
		// spawn enemies that are closer to the player

		scene = GameObject.Find("Controller").GetComponent<SceneController>();
	}


}
