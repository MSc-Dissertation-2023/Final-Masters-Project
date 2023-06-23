using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] string itemName;
    private PlayerCharacter player;
    public float healthRestoreAmount = 15.0f;

    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerCharacter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Item collected: {itemName}");
        player.Heal(healthRestoreAmount);
        Destroy(this.gameObject);
    }
}
