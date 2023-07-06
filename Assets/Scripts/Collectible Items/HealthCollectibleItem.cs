using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectibleItem : CollectibleItem
{
    public float healthRestoreAmount = 15.0f;

    protected override void ApplyEffect()
    {
        playerManager.HealPlayer(healthRestoreAmount);
    }
}
