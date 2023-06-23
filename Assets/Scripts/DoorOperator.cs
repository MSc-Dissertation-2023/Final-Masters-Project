using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOperator : MonoBehaviour
{
    [SerializeField] OpeningDoor doorOne;
    [SerializeField] OpeningDoor doorTwo;

    public void Operate()
    {
        doorOne.OperateDoor();
        doorTwo.OperateDoor();
    }
}
