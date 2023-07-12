using System;

public class Rule
{
    public float weight;
    public Action rule;
    public string description;

    public Rule(float initialWeight, Action Rule, string description)
    {
        this.weight = initialWeight;
        this.rule = Rule;
        this.description = description;
    }

}
