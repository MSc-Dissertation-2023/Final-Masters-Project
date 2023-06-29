public class DamageCollectibleItem : CollectibleItem
{

    // Update is called once per frame
    protected override void ApplyEffect()
    {
        player.damage += 5;
    }
}
