using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class TokenManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public static string token { get; private set; }

    // Start is called before the first frame update
    public void Startup()
    {
        Debug.Log("Token Manager starting...");

        StartCoroutine(GetToken());

        status = ManagerStatus.Started;
    }

    IEnumerator GetToken() {
        // string ApiURL = System.Environment.GetEnvironmentVariable("API_URL");
        using (UnityWebRequest www = UnityWebRequest.Post(
            "www.mdk2023.com/guest_tokens", "", "application/json"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Get the server's response
                string responseText = www.downloadHandler.text;
                // Save the server's response
                token = responseText;

                Debug.Log("API Request complete!");
                Debug.Log("Received token: " + token);
            }
        }
    }
}
