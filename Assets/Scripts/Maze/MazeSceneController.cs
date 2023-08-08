using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MazeSceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject OuterWall;

    [SerializeField]
    private int width;

    [SerializeField]
    private int depth;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private GameObject exit;

    [SerializeField]
    private GameObject healthPickup;

    public int numberOfHealthPickUps;

    [SerializeField, Header("Broadcast maze sizes for generators.")]
    private PublishMazeSizesEvent PublishWithDepth;

    [SerializeField, Header("Broadcast time for score calculation.")]
    private SendScoreInfoEvent PublishTime;

    [SerializeField]
    private GameObject MazeController;

    private MazeGenerator RecBackAndPrim;
    private MazeGeneratorDivision RecDiv;
    private GenerateMazeGA GenAlgo;

    [SerializeField] TMP_Text timer;

    private int time;
    
    void Awake()
    {
        RecBackAndPrim = MazeController.GetComponent<MazeGenerator>();
        RecDiv = MazeController.GetComponent<MazeGeneratorDivision>();
        GenAlgo = MazeController.GetComponent<GenerateMazeGA>();

        if (Managers.Maze.Algorithm == MazeAlgorithm.RecursiveBacktracker)
        {
            RecBackAndPrim.trueForRB = true;
            RecBackAndPrim.enabled = true;
        }
        if (Managers.Maze.Algorithm == MazeAlgorithm.PrimsAlgorithm)
        {
            RecBackAndPrim.trueForRB = false;
            RecBackAndPrim.enabled = true;
        }
        if (Managers.Maze.Algorithm == MazeAlgorithm.RecursiveDivision)
        {
            RecDiv.enabled = true;
        }
        if (Managers.Maze.Algorithm == MazeAlgorithm.GeneticAlgorithm)
        {
            GenAlgo.enabled = true;
        }
    }

    void Update()
    {
        time = (int)Time.timeSinceLevelLoad;
        timer.text = $"Time: {time}";
    }

    public void BuildOuterWalls()
    {
        for (int i = 0; i < width; i++)
        {
            Instantiate(OuterWall, new Vector3(i * 5, 2.5f, -2.5f), Quaternion.Euler(0, 90, 0));
            Instantiate(OuterWall, new Vector3(i * 5, 2.5f, depth * 5 - 2.5f), Quaternion.Euler(0, 90, 0));
        }
        for (int j = 0; j < depth; j++)
        {
            Instantiate(OuterWall, new Vector3(-2.5f, 2.5f, j * 5), Quaternion.identity);
            Instantiate(OuterWall, new Vector3(width * 5 - 2.5f, 2.5f, j * 5), Quaternion.identity);
        }
    }

    public void SpawnPrefabs()
    {
        float cornerValueWidth = 5f * (width - 1);
        float cornerValueDepth = 5f * (depth - 1);

        Instantiate(player, new Vector3(0f, 1.5f, 0f), Quaternion.identity);
        Instantiate(enemy, new Vector3(0f, 1.5f, cornerValueDepth), Quaternion.identity);
        Instantiate(enemy, new Vector3(cornerValueWidth, 1.5f, 0f), Quaternion.identity);
        Instantiate(exit, new Vector3(cornerValueWidth, 2.5f, cornerValueDepth + 2.5f), Quaternion.identity);

        for(int i = 0; i < numberOfHealthPickUps; i++)
        {
            float x = Random.Range(0, width);
            float z = Random.Range(0, depth);

            Instantiate(healthPickup, new Vector3(x * 5, 2f, z * 5), Quaternion.identity);

        }
        Managers.Player.OnSceneLoaded();
    }

    public void PublishMazeSizes()
    {
        PublishWithDepth.Invoke(width, depth);
    }

    public void PublishGameTime()
    {
        PublishTime.Invoke(time);
    }
}
