using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class EnterCodePopup : MonoBehaviour
{
    private string puzzleCode;
    private int attempts;
    [SerializeField]
    private InputField enterCodeField;

    [SerializeField] TMP_Text attemptsDisplay;
    void Start()
    {
        int attempts = 3;
        attemptsDisplay.text = $"Attempts: {attempts}";
    }

    public void Open()
    {
        gameObject.SetActive(true);
        GameEvents.NotifyPaused();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        GameEvents.NotifyUnpaused();
    }

    void OnEnable()
    {
        MazeEvents.SendCode += SetCode;

    }
    void OnDisable()
    {
        MazeEvents.SendCode -= SetCode;
        
    }

    private void SetCode(string code)
    {
        puzzleCode = code;
    }

    
}
