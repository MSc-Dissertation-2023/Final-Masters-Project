public class AmmoCollectibleItem : CollectibleItem
{
    public int ammoRestoreAmount = 50;

    protected override void ApplyEffect()
    {
        playerManager.GiveAmmo(ammoRestoreAmount);
    }
}
