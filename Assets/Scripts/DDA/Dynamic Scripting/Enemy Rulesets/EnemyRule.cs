using System;

public class EnemyRule : Rule
{
    // Calls the constructor of the base class
    public EnemyRule(float initialWeight, Action Rule, string description) : base(initialWeight, Rule, description) { }

    private void apply(Enemy enemy) {
        Rule(enemy);
    }

    private void IncreaseEnemyDamage() {

	}

	private void DecreaseEnemyDamage() {

	}

	private void IncreaseEnemySpeed() {

	}

	private void DecreaseEnemySpeed() {

	}

	private void IncreaseEnemyDodging() {

	}

	private void DecreaseEnemyDodging() {

	}
}
