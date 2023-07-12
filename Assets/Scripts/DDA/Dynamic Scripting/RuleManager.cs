using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesetManager : MonoBehaviour
{
    FitnessCalculator fitnessCalculator;
    // EnemyRulesets enemyRulesets;
    // EnemyRuleset enemyRuleset;
    // Start is called before the first frame update
    void Start()
    {
        fitnessCalculator = GameObject.Find("Player Metrics").GetComponent<FitnessCalculator>();
        InvokeRepeating("SelectRules", 15, 10);
    }
}
