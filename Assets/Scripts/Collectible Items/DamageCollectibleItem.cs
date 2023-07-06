public class DamageCollectibleItem : CollectibleItem
{

    // Update is called once per frame
    protected override void ApplyEffect()
    {
        playerManager.IncreaseDamage(5);
    }
}
