using System;

public class GameRule : Rule
{
    // Calls the constructor of the base class
    public GameRule(float initialWeight, Action Rule, string description) : base(initialWeight, Rule, description) { }
}
