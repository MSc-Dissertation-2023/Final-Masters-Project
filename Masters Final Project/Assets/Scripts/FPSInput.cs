using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

/*
 * A class which allows the player to move using direction arrows
 */
public class FPSInput : MonoBehaviour
{
    // Create variable for the character speed.
    public float speed = 6.0f;

    public float gravity = -9.8f;

    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Allows player to move using the diectional arrows on keyboard
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveZ = Input.GetAxis("Vertical") * speed;
        //Create vector for a new location
        Vector3 movement = new Vector3(moveX, 0, moveZ);
        //Clamp total distance by speed variable
        movement = Vector3.ClampMagnitude(movement, speed);

        //Find new location in reation to delta time
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        //Keep the player grounded
        movement.y = gravity;

        //Move the the player object
        charController.Move(movement);

       
    }
}
