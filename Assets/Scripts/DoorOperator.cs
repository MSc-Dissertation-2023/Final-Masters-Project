using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A simple class to allow for wall buttons to operate door
 */
public class DoorOperator : MonoBehaviour
{
    //Doors to be opened/closed
    [SerializeField] OpeningDoor doorOne;
    [SerializeField] OpeningDoor doorTwo;

    //When interacted with, operate the door objects
    public void Operate()
    {
        doorOne.OperateDoor();
        if (doorOne != doorTwo)
        {
            doorTwo.OperateDoor();
        }
        
    }
}
