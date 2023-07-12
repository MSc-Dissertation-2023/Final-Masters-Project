using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleset : MonoBehaviour
{
    public List<GameRule> rulesets;
    SceneController scene;

    void Start()
    {
        scene = GameObject.Find("Controller").GetComponent<SceneController>();
    }

    public void ApplyRules(Enemy enemy) {
        foreach (GameRule gameRule in rulesets) {
            switch (gameRule.rule) {
                case "IncreaseEnemyCount":
                    IncreaseEnemyCount();
                    break;
                case "DecreaseEnemyCount":
                    DecreaseEnemyCount();
                    break;
            }
        }
    }

    public void IncreaseEnemyCount() {
		scene.IncreaseEnemyCount();
	}

	private void DecreaseEnemyCount() {
		scene.DecreaseEnemyCount();
	}
}
