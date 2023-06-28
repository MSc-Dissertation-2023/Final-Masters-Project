using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A simple script to control openning of doors
 */
public class OpeningDoor : Switchable
{
    [SerializeField] Vector3 offset;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip openSound;
    [SerializeField] AudioClip closeSound;

    //Whether door is open
    public bool open;
    public override bool IsActive { get { return open; } }


    //Method to open the door
    public override void Activate()
    {
        //Move up if closed
        Vector3 pos = transform.position + offset;
        transform.position = pos;
        soundSource.PlayOneShot(closeSound);
        open = true;
    }

    //Method to close the door
    public override void Deactivate()
    {
        //Move down if open
        Vector3 pos = transform.position - offset;
        transform.position = pos;
        soundSource.PlayOneShot(openSound);
        open = false;
    }
}
