using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGamePopup : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
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
}
