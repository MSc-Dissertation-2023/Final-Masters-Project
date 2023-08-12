using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class EndGamePopup : MonoBehaviour
{
    private PlayerCharacter playerCharacter;

    [SerializeField]
    private InputField enterNameField;

    [SerializeField, Header("Request time from scene controller to work out the score.")]
    private RequestScoreEvent requestScore;

    private bool scoreSaved = false;

    public void Open()
    {
        gameObject.SetActive(true);
        GameEvents.NotifyPaused();
        if (GameObject.Find("MazeController") != null)
        {
            Managers.Player.SaveHealth();
            requestScore.Invoke();
            Managers.Data.SaveStats();
        }
        else
        {
            enterNameField.text = PlayerPrefs.GetString("Name");
        }
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
            StartCoroutine(CallAPI());
            PlayerPrefs.SetString("Name", enterNameField.text);
        }
    }

    IEnumerator CallAPI()
    {
        string name = enterNameField.text;
        int score = Managers.Score.score;

        using (UnityWebRequest www = UnityWebRequest.Post($"www.mdk2023.com/leaderboards?name={name}&score={score}", "", "application/json"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("API Request complete!");
                scoreSaved = true;
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }
}
