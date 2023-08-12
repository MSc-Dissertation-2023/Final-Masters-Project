using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;

public class LeaderboardPopup : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;

    public int tableEntries = 100;
    public float templateHeight = 20f;

    public void Open()
    {
        gameObject.SetActive(true);

        entryTemplate.gameObject.SetActive(false);

        StartCoroutine(CallAPI());
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    IEnumerator CallAPI()
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"www.mdk2023.com/leaderboards"))
        {
            www.SetRequestHeader("Content-Type", "application/json"); // Set content type for the data you're sending.
            www.SetRequestHeader("Accept", "application/json"); // Set the type of data you're expecting back.
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                var entries = JsonConvert.DeserializeObject<List<LeaderboardEntry>>(www.downloadHandler.text);
                PopulateTable(entries);
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }

    private void PopulateTable(List<LeaderboardEntry> dataEntries)
    {
        for (int i = 0; i < tableEntries && i < dataEntries.Count; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            entryTransform.Find("Rank").GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
            entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = dataEntries[i].score.ToString();
            entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = dataEntries[i].name;

        }
    }

    public class LeaderboardEntry
    {
        public int id { get; set; }
        public string name { get; set; }
        public int score { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
