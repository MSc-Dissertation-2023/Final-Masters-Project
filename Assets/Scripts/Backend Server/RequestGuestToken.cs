using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class RequestGuestToken : MonoBehaviour
{
    string Token;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetToken());
    }

    IEnumerator GetToken() {
        string ApiURL = System.Environment.GetEnvironmentVariable("API_URL");
        using (UnityWebRequest www = UnityWebRequest.Post(ApiURL, "", "application/json"))
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
                Token = responseText;

                Debug.Log("API Request complete!");
                Debug.Log("Received token: " + Token);
            }
        }
    }
}
