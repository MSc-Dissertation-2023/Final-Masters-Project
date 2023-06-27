using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A simple script to control openning of doors
 */
public class OpeningDoor : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip openSound;
    [SerializeField] AudioClip closeSound;

    //Whether door is open
    public bool open;

    //Open or close doors
    public void OperateDoor()
    {
        if (open)
        {
            //Move down if open
            Vector3 pos = transform.position - offset;
            transform.position = pos;
            soundSource.PlayOneShot(openSound);

        }
        else
        {
            //Move up if closed
            Vector3 pos = transform.position + offset;
            transform.position = pos;
            soundSource.PlayOneShot(closeSound);
        }
        open = !open;
    }
}
