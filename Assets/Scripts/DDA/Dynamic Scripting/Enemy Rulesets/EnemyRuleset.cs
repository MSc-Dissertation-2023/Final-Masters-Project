using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyRuleset : MonoBehaviour {
    public List<EnemyRule> rulesets = new List<EnemyRule>();
    // public Enemy enemy;
    // float enemySpeed = 0.0f;
    float enemyDamage = 15.0f;
    float enemySpeed = 5.0f;

    public void ApplyRules(Enemy enemy) {
        foreach (EnemyRule enemyRule in rulesets) {
            switch (enemyRule.rule) {
                case "IncreaseEnemyDamage":
                    IncreaseEnemyDamage(enemy);
                    break;
                case "DecreaseEnemyDamage":
                    DecreaseEnemyDamage(enemy);
                    break;
                case "IncreaseEnemySpeed":
                    IncreaseEnemySpeed(enemy);
                    break;
                case "DecreaseEnemySpeed":
                    DecreaseEnemySpeed(enemy);
                    break;
                // case "IncreaseEnemyDodging":
                //     IncreaseEnemyDodging(enemy);
                //     break;
                // case "DecreaseEnemyDodging":
                //     DecreaseEnemyDodging(enemy);
                //     break;
            }
        }
    }

    private void IncreaseEnemyDamage(Enemy enemy) {
        enemyDamage += 1;
        enemy.setDamage(enemyDamage);
	}

	private void DecreaseEnemyDamage(Enemy enemy) {
        enemyDamage -= 1;
        enemy.setDamage(enemyDamage);
	}

	private void IncreaseEnemySpeed(Enemy enemy) {
        enemySpeed += 1;
        Debug.Log("Increase Enemy Speed");
        enemy.setSpeed(enemySpeed);
	}

	private void DecreaseEnemySpeed(Enemy enemy) {
        enemySpeed -=1;
        Debug.Log("Decrease Enemy Speed");
        enemy.setSpeed(enemySpeed);
	}

	private void IncreaseEnemyDodging(Enemy enemy) {

	}

	private void DecreaseEnemyDodging(Enemy enemy) {

	}
}
