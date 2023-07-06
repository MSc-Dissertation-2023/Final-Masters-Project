using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] string itemName;
    protected PlayerManager playerManager;

    public void Start()
    {
        // player object is needed inside the apply effect of its child items
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Item collected: {itemName}");
        ApplyEffect();
        Destroy(this.gameObject);
    }

    // This function should be overridden in subclasses to implement different effects
    protected virtual void ApplyEffect()
    {
    }
}
