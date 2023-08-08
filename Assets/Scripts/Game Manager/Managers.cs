using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent (typeof(InventoryManager))]
[RequireComponent(typeof(MissionManager))]

public class Managers : MonoBehaviour
{
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }
    public static AudioManager Audio { get; private set; }
    public static MissionManager Mission { get; private set; }
    public static ScoreManager Score { get; private set; }
    public static MazeGenerationManager Maze { get; private set; }
    public static DataManager Data { get; private set; }
    public static TokenManager Token { get; private set; }


    private List<IGameManager> startSequence;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();
        Audio = GetComponent<AudioManager>();
        Mission = GetComponent<MissionManager>();
        Score = GetComponent<ScoreManager>();
        Maze = GetComponent<MazeGenerationManager>();
        Data = GetComponent<DataManager>();
        Token = GetComponent<TokenManager>();

        startSequence = new List<IGameManager>();
        startSequence.Add(Player);
        startSequence.Add(Inventory);
        startSequence.Add(Audio);
        startSequence.Add(Mission);
        startSequence.Add(Score);
        startSequence.Add(Maze);
        startSequence.Add(Data);
        startSequence.Add(Token);

        StartCoroutine(StartupManagers());
    }

    // Loop over game managers and start them
    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in startSequence)
        {
            manager.Startup();
        }

        yield return null;

        int numModules = startSequence.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach (IGameManager manager in startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }

                if (numReady > lastReady)
                {
                    Debug.Log($"Progress: {numReady}/{numModules}");
                    StartupEvents.NotifyProgress(numReady, numModules);
                }
            }
            yield return null;
        }

        Debug.Log("All managers started up!");
        StartupEvents.NotifyManagersStarted();
    }
}
