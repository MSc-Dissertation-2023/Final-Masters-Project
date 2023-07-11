using System;

public class EnemyRule
{
    public float weight;
    public Action rule;
    public string description;

    public EnemyRule(float initialWeight, Action Rule, string description)
    {
        this.weight = initialWeight;
        this.rule = Rule;
        this.description = description;
    }
}
