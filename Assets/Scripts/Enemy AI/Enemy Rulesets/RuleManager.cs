using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
    FitnessCalculator fitnessCalculator;
    EnemyRulesets enemyRulesets;
    EnemyRuleset enemyRuleset;
    // Start is called before the first frame update
    void Start()
    {
        fitnessCalculator = GameObject.Find("Player Metrics").GetComponent<FitnessCalculator>();
        enemyRulesets = GameObject.Find("DDA").GetComponent<EnemyRulesets>();
        InvokeRepeating("SelectRules", 15, 10);
    }

    private int calculateScriptSize() {
        double fitness = fitnessCalculator.GetFitness();
        // fitness starts at 30, then 60, 90, 119, 145, 176, 207, 226, 290.5, 314, 215.5, 232.5, 250, 264.5, 284, 300, 253. Highest is 342.5
        switch(fitness) {
            // case fitness when (fitness > 100)
        }
        return 0;
    }

    public void SelectRules() {
        float sumWeights = 0;
        foreach (EnemyRule rule in enemyRulesets.rulesets) {
            sumWeights = sumWeights + rule.weight;
        }

        int scriptSize = calculateScriptSize();

        for (int i = 0; i < scriptSize; i++) {
            int tries = 0;
            bool lineadded = false;
            int maxtries = 0;

            // repeated roulette wheel selection
            while (tries < maxtries && !lineadded) {
                int j = 0;
                float sum = 0;
                int selected = -1;
                float fraction = RouletteWeights(sumWeights);
                while (selected < 0) {
                    sum += enemyRulesets.rulesets[j].weight;
                    if (sum > fraction) {
                        selected = j;
                    } else {
                        j = j + 1;
                    }
                }
                lineadded = InsertInScript(enemyRulesets.rulesets[j]);
                tries += 1;
            }

        }



        // // Check player performance, and adjust ruleset weights for next time
        // AdjustRuleWeights();
        // enemyRulesets.IncreaseEnemyCount();
    }

    private float RouletteWeights(float sumWeights) {
        // EnemyRule chosenRule;
        // Random r = new Random();
        float randomFloat = Random.Range(0.0f,1.0f) * sumWeights;
        // float total = 0;
        // foreach (EnemyRule rule in enemyRulesets.rulesets) {

        //     if (randomFloat > total && randomFloat <= (total + rule.weight)) {
        //         chosenRule = rule;
        //         break;
        //     }
        //     total += rule.weight;
        // }

        return randomFloat;
    }

    private bool InsertInScript(EnemyRule rule) {
        foreach (EnemyRule currentRule in enemyRuleset.rulesets) {
            if (currentRule.description == rule.description) {
                return false;
            }
        }
        enemyRuleset.rulesets.Add(rule);
        return true;
    }

}
