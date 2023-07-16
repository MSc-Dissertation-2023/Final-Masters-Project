using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MazeEvents.NotifyObjectiveReached();
            Debug.Log("Trigger entered");
        }  
    }
}
