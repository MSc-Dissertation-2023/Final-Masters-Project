using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyRuleset : MonoBehaviour {
    public List<EnemyRule> rulesets;
    // public Enemy enemy;

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
                case "IncreaseEnemyDodging":
                    IncreaseEnemyDodging(enemy);
                    break;
                case "DecreaseEnemyDodging":
                    DecreaseEnemyDodging(enemy);
                    break;
            }
        }
    }

    private void IncreaseEnemyDamage(Enemy enemy) {
        enemy.setDamage(enemy.GetDamage() + 1.0f);
	}

	private void DecreaseEnemyDamage(Enemy enemy) {
        enemy.setDamage(enemy.GetDamage() - 1.0f);
	}

	private void IncreaseEnemySpeed(Enemy enemy) {
        enemy.setSpeed(enemy.speed += 1);
	}

	private void DecreaseEnemySpeed(Enemy enemy) {
        enemy.setSpeed(enemy.speed -= 1);
	}

	private void IncreaseEnemyDodging(Enemy enemy) {

	}

	private void DecreaseEnemyDodging(Enemy enemy) {

	}
}
