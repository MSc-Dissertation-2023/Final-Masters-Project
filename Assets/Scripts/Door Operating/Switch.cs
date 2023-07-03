using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A simple class to allow for wall buttons to operate door
 */
public class Switch : MonoBehaviour
{
    //Device to be activated/deactivated
    public Switchable device;

    //When interacted with, operate
    public void Operate()
    {
       //Deactivate active devices and activate deactive devices
       if (device.IsActive)
        {
            device.Deactivate();
        }
       else
        {
            device.Activate();
        }
    }
}
