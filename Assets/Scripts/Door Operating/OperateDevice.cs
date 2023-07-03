using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class for player to operate device
 */
public class OperateDevice : MonoBehaviour
{
    //Radius to operate object
    public float radius = 1.5f;

    void Update()
    {
        //When the 'C/ key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Find game objects within defined radius 
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider hitCollider in hitColliders)
            {
                Vector3 hitPosition = hitCollider.transform.position;
                hitPosition.y = transform.position.y;

                //Only if the object is infront of the player
                Vector3 direction = hitPosition - transform.position;
                if (Vector3.Dot(transform.forward, direction.normalized) > 0.5f)
                {
                    //Call operate method on game objects if exists
                    hitCollider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
