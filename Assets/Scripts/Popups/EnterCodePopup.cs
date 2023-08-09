using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class EnterCodePopup : MonoBehaviour
{
    [SerializeField, Header("Broadcast message to request puzzle code.")]
    private GetCodeEvent getCode;

    private string puzzleCode;
    private int attempts;

    [SerializeField]
    private InputField enterCodeField;
    [SerializeField] TMP_Text attemptsDisplay;
    void Start()
    {
        attempts = 3;
        attemptsDisplay.text = $"Attempts: {attempts}";
    }

    public void Open()
    {
        gameObject.SetActive(true);
        GameEvents.NotifyPaused();
        if (puzzleCode == null)
        {
            getCode.Invoke();
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
        GameEvents.NotifyUnpaused();
    }

    public void SetCode(string code)
    {
        puzzleCode = code;
        //Debug.Log($"puzzleCode is {puzzleCode}");
    }

    public void OnSubmit()
    {
        string compare = enterCodeField.text;
        if (compare != null || compare != "")
        {
            //Debug.Log(compare);
            //Debug.Log($"puzzleCode is {puzzleCode}");
            if (compare.Equals(puzzleCode))
            {
                Close();
                Managers.Mission.ReachObjective();
            }
            else
            {
                attempts--;
                attemptsDisplay.text = $"Attempts: {attempts}";
                if (attempts == 0)
                {
                    Close();
                    GameEvents.NotifyEnd();
                }
            }

        }
    }
}
