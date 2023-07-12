using System;

public class Rule
{
    public float weight;
    public string rule;
    public string description;

    public Rule(float initialWeight, string rule, string description)
    {
        this.weight = initialWeight;
        this.rule = rule;
        this.description = description;
    }

}
