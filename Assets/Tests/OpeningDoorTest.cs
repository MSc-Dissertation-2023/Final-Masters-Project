using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class OpeningDoorTest
{
    public OpeningDoor door { get; private set; }


    [SetUp]
    public void SetUp()
    {
        GameObject gameObject = new GameObject("Opening Door");
        door = gameObject.AddComponent<OpeningDoor>();
        door.open = true;
    }

    [Test]
    public void TestOpenClose()
    {
        door.Deactivate();
        Assert.AreEqual(door.IsActive, false);
        door.Activate();
        Assert.AreEqual(door.IsActive, true);
    }
    
}
