using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGamePopup : MonoBehaviour
{
    private PlayerCharacter playerCharacter;

    [SerializeField]
    private InputField enterNameField;

    private bool scoreSaved = false;

    public void Open()
    {
        gameObject.SetActive(true);
        GameEvents.NotifyPaused();
    }

    public void Close()
    {
        gameObject.SetActive(false);     
    }

    public void restart()
    {
        GameObject managers = GameObject.Find("GameManager");
        Destroy(managers);
        SceneManager.LoadScene("Startup");
    }

    public void saveScore()
    {
        if (!scoreSaved) 
        {
            scoreSaved = true;
        }
    }
}
