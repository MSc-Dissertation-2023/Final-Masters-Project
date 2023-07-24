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
                // Handle the response and store the token
                string responseText = www.downloadHandler.text;
                // Assuming the token is provided as a JSON string in the response
                // You may need to adapt this to the actual format of the API response
                // For example, if the token is provided as a direct string, you can directly assign it to the 'token' variable.
                // If it's in a more complex format like a JSON object, you'll need to deserialize it first.
                Token = responseText;

                Debug.Log("API Request complete!");
                Debug.Log("Received token: " + Token);
            }
        }
    }
}
