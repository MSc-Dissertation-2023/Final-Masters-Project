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
        gameObject.SetActive(false);
        playerCharacter = GameObject.Find("Player").GetComponent<PlayerCharacter>();
        if (playerCharacter.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
