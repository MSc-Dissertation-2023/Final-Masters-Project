public class HealthCollectibleItem : CollectibleItem
{
    public float healthRestoreAmount = 15.0f;

    protected override void ApplyEffect()
    {
        player.Heal(healthRestoreAmount);
    }
}
