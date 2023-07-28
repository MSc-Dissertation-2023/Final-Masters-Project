using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerManagerTest
{
    public ManagerStatus status { get; private set; }
    [SerializeField] PlayerManager playerManager;

    [SetUp]
    public void SetUp()
    {
        GameObject gameObject = new GameObject("Player Manager");
        playerManager = gameObject.AddComponent<PlayerManager>();

        GameObject playerGameObject = new GameObject("Player Character");
        PlayerCharacter playerCharacter = playerGameObject.AddComponent<PlayerCharacter>();

        GameObject soundSource = new GameObject("Audio");
        AudioSource audio = soundSource.AddComponent<AudioSource>();
        playerCharacter.soundSource = audio;

        playerManager.playerCharacter = playerCharacter;

    }

    // A Test behaves as an ordinary method
    [Test]
    public void PlayerManagerTestSimplePasses()
    {
        Assert.IsNotNull(playerManager.playerCharacter);
    }

    [Test]
    public void PlayerManagerAppliesDamage()
    {
        playerManager.ApplyDamage(15);
        Assert.AreEqual(playerManager.playerCharacter.health, 100 - 15);
    }

    [Test]
    public void PlayerManagerHealsPlayer()
    {
        playerManager.playerCharacter.health = 85;
        playerManager.HealPlayer(15);
        Assert.AreEqual(playerManager.playerCharacter.health, 100);
    }

    [Test]
    public void PlayerManagerRefillsAmmo()
    {
        playerManager.playerCharacter.ammo = 50;
        playerManager.GiveAmmo(15);
        Assert.AreEqual(playerManager.playerCharacter.ammo, 65);
    }

    [Test]
    public void PlayerManagerConsumesAmmo()
    {
        playerManager.playerCharacter.ammo = 50;
        playerManager.ConsumeAmmo();
        Assert.AreEqual(Managers.Player.playerCharacter.ammo, 49);
    }
}
