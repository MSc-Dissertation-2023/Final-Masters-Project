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
            }
        }
        Debug.Log($"Enemy Damage: {enemyDamage}, Enemy Speed: {enemySpeed}");
    }

    private void IncreaseEnemyDamage(Enemy enemy) {
        if (enemyDamage >= 50.0f) return;
        enemyDamage += 1.0f;
        enemy.setDamage(enemyDamage);
	}

	private void DecreaseEnemyDamage(Enemy enemy) {
        if (enemyDamage <= 5.0f) return;
        enemyDamage -= 1.0f;
        enemy.setDamage(enemyDamage);
	}

	private void IncreaseEnemySpeed(Enemy enemy) {
        if (enemySpeed >= 10.0f) return;
        enemySpeed += 1.0f;
        enemy.setSpeed(enemySpeed);
	}

	private void DecreaseEnemySpeed(Enemy enemy) {
        if (enemyDamage <= 2.0f) return;
        enemySpeed -= 1.0f;
        enemy.setSpeed(enemySpeed);
	}
}
