using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int levelOneHealth { get; set; }

    public int levelOneTime { get; set; }

    

    public void Startup()
    {
        Debug.Log("Data Manager manager starting...");


        status = ManagerStatus.Started;
    }

    public void SaveStats()
    {

        StartCoroutine(CallAPILevelOne());

    }

    IEnumerator CallAPILevelOne()
    {


        using (UnityWebRequest www = UnityWebRequest.Post($"www.mdk2023.com/StageOneStats?health={levelOneHealth}&time={levelOneTime}&token={Managers.Token.token}", "", "application/json"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Level One API Request complete!");
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }
}
