using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGamePopup : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    public void Open()
    {
        /*Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;*/
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        playerCharacter = GameObject.Find("Player").GetComponent<PlayerCharacter>();
        if (playerCharacter.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }       
    }
}
