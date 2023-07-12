using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleManager : MonoBehaviour
{
    FitnessCalculator fitnessCalculator;
    GameRulesets gameRulesets;
    GameRuleset gameRuleset;
    // Start is called before the first frame update

    void Start()
    {
        fitnessCalculator = GameObject.Find("Player Metrics").GetComponent<FitnessCalculator>();
        gameRulesets = GameObject.Find("DDA").GetComponent<GameRulesets>();
        InvokeRepeating("SelectRules", 15, 10);
    }

    private int calculateScriptSize() {
        // double fitness = fitnessCalculator.GetFitness();
        // fitness starts at 30, then 60, 90, 119, 145, 176, 207, 226, 290.5, 314, 215.5, 232.5, 250, 264.5, 284, 300, 253. Highest is 342.5
        // switch(fitness) {
        //     // case fitness when (fitness > 100)
        //     case <= 100:

        //         break;
        // }
        return 1;
    }

    public void SelectRules() {
        float sumWeights = 0;
        foreach (GameRule rule in gameRulesets.rulesets) {
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
                    sum += gameRulesets.rulesets[j].weight;
                    if (sum > fraction) {
                        selected = j;
                    } else {
                        j = j + 1;
                    }
                }
                lineadded = InsertInScript(gameRulesets.rulesets[j]);
                tries += 1;
            }
        }
    }

    private float RouletteWeights(float sumWeights) {
        float randomFloat = Random.Range(0.0f,1.0f) * sumWeights;

        return randomFloat;
    }

    private bool InsertInScript(GameRule rule) {
        foreach (GameRule currentRule in gameRuleset.rulesets) {
            if (currentRule.description == rule.description) {
                return false;
            }
        }
        gameRuleset.rulesets.Add(rule);
        return true;
    }
}
