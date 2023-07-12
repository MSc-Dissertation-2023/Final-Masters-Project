using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicScripting : MonoBehaviour
{
    EnemyRuleManager enemyRuleManager;
    GameRuleManager gameRuleManager;

    void Start()
    {
        enemyRuleManager = GetComponent<EnemyRuleManager>();
        gameRuleManager = GetComponent<GameRuleManager>();
        InvokeRepeating("SelectRules", 15, 10);
    }

    void SelectRules() {
        enemyRuleManager.SelectRules();
        gameRuleManager.SelectRules();
    }
}
