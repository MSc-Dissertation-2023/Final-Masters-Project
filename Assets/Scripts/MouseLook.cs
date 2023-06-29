using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class which allows the player to use the mouse to look
 */
public class MouseLook : MonoBehaviour
{
    //Enums represent looking in both X and Y axis
    public enum RotationAxes
    {
        MouseX = 0,
        MouseY = 1
    }

    //Sensitivity variables
    public const float baseSpeed = 9.0f;
    public float sensHor = baseSpeed;
    public float sensVer = baseSpeed;

    //Temporary sensitivity variables to hold values while paused 
    public float tempSens = baseSpeed;

    //Create a max and min vertical angle to prevent camara being able to fully rotate vertically
    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    private float vertRot = 0;

    public RotationAxes axes;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }


    void Update()
    {
        //Represents horizontal rotation
        if (axes == RotationAxes.MouseX)
        {
            //rotate X axis via mouse input relative to sensitivity
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            //Increment vertical rotation by mouse input relative to the sensitivity
            vertRot -= Input.GetAxis("Mouse Y") * sensVer;
            //Clamp the rotation between variable limits set
            vertRot = Mathf.Clamp(vertRot, minVert, maxVert);

            //Keep the same Y angle
            float horiRot = transform.localEulerAngles.y;

            //Create a new vector from the stored roation values
            transform.localEulerAngles = new Vector3(vertRot, horiRot, 0);
        }

    }

    void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SENSITIVITY_CHANGED, OnSensitivityChanged);
        Messenger.AddListener(GameEvent.GAME_PAUSED, OnGamePaused);
        Messenger.AddListener(GameEvent.GAME_UNPAUSED, OnGameUnpaused);
    }
    void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SENSITIVITY_CHANGED, OnSensitivityChanged);
        Messenger.RemoveListener(GameEvent.GAME_PAUSED, OnGamePaused);
        Messenger.RemoveListener(GameEvent.GAME_UNPAUSED, OnGameUnpaused);
    }

    private void OnSensitivityChanged(float value)
    {
        tempSens = baseSpeed * value;

    }

    private void OnGamePaused()
    {
        tempSens = sensHor;
        sensHor = 0; 
        sensVer = 0;
    }

    private void OnGameUnpaused()
    {
        sensHor = tempSens;
        sensVer = tempSens;
    }
}
