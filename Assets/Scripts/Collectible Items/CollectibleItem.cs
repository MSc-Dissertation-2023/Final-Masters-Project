using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] string itemName;
    protected PlayerCharacter player;

    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerCharacter>();
    }

    private void OnTriggerEnter(Collider other)
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

