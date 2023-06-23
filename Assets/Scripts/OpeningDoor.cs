using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
    [SerializeField] Vector3 offset;

    public bool open;

    public void OperateDoor()
    {
        if (open)
        {
            Vector3 pos = transform.position - offset;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + offset;
            transform.position = pos;
        }
        open = !open;
    }
}
