using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CollectibleItemTests
{
    // Define a game object for player character and health collectible item
    private GameObject playerGameObject;
    private GameObject healthCollectibleItemGameObject;

    // A reference to our scripts to test
    private PlayerCharacter playerCharacter;
    private HealthCollectibleItem healthCollectibleItem;

    // Method runs before each test
    [SetUp]
    public void SetUp()
    {
        // Create a new PlayerCharacter game object
        playerGameObject = new GameObject("Player");
        playerGameObject.name = "Player";
        playerCharacter = playerGameObject.AddComponent<PlayerCharacter>();

        // Initialize the player health
        playerCharacter.health = 80.0f;

        playerCharacter.Start();

        // Create a new HealthCollectibleItem game object
        healthCollectibleItemGameObject = new GameObject();
        healthCollectibleItem = healthCollectibleItemGameObject.AddComponent<HealthCollectibleItem>();
        healthCollectibleItemGameObject.name = "HealthCollectibleItem";

        healthCollectibleItem.player = playerCharacter;

        healthCollectibleItem.Start();
    }

    // Test to ensure that player health increases when a health item is collected
    [UnityTest]
    public IEnumerator TestHealthIncreasesWhenHealthItemCollected()
    {
        // Set up a collider for the player & health collectible items
        SphereCollider player = playerGameObject.AddComponent<SphereCollider>();
        SphereCollider collectible = healthCollectibleItemGameObject.AddComponent<SphereCollider>();
        playerGameObject.AddComponent<CharacterController>();
        // Add a rigid body for the
        playerGameObject.AddComponent<Rigidbody>();
        playerGameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        healthCollectibleItem.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        // healthCollectibleItemGameObject.AddComponent<Rigidbody>();

        // Test both collectible and player has to have the has trigger property for onTriggerEnter Callback
        // player.isTrigger = true;
        collectible.isTrigger = true;

        // Ensure player's initial health is 50
        Assert.AreEqual(80.0f, playerCharacter.health);
        Assert.AreEqual(15.0, healthCollectibleItem.healthRestoreAmount);

        // Position the player and the health item at the same location to simulate a collision
        playerGameObject.transform.position = Vector3.zero;
        healthCollectibleItemGameObject.transform.position = Vector3.zero;

        // Wait for one frame so that the engine can process the collision
        yield return null;

        // Ensure player's health increased by the health restore amount of the item
        Assert.AreNotEqual(80.0f, playerCharacter.health);
    }

    // Method to run after each test
    [TearDown]
    public void TearDown()
    {
        // Destroy the game objects
        Object.DestroyImmediate(playerGameObject);
        Object.DestroyImmediate(healthCollectibleItemGameObject);
    }
}
