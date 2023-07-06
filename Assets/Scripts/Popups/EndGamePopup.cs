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
<<<<<<< HEAD
        gameObject.SetActive(false);     
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
=======
        gameObject.SetActive(false);
        playerCharacter = GameObject.Find("Player").GetComponent<PlayerCharacter>();
        if (playerCharacter.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
>>>>>>> e494f579d1cea2b871c307e2cf367ed89f922ed7
    }
}
