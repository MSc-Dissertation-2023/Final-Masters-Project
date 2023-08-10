using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class Puzzle : MonoBehaviour
{
    [SerializeField, Header("Broadcast code for the puzzle.")]
    private SendCodeEvent sendCode;

    [SerializeField] 
    private Image UISquare1;
    [SerializeField] 
    private Image UISquare2;
    [SerializeField] 
    private Image UISquare3;

    [SerializeField] 
    private GameObject zero;
    [SerializeField] 
    private GameObject one;
    [SerializeField] 
    private GameObject two;
    [SerializeField] 
    private GameObject three;
    [SerializeField] 
    private GameObject four;
    [SerializeField] 
    private GameObject five;
    [SerializeField] 
    private GameObject six;
    [SerializeField] 
    private GameObject seven;
    [SerializeField] 
    private GameObject eight;
    [SerializeField] 
    private GameObject nine;

    private int width;
    private int depth;

    private GameObject[] SpawnedDigits;


    private int[] Code;
    private Color[] Colours = {Color.red, Color.blue, Color.yellow};

    void Start()
    {
        GenerateCode();
        SetSqaureColours();
        spawnDigits();
    }

    void Update()
    {
        foreach(GameObject digit in SpawnedDigits)
        {
            digit.transform.Rotate(0.0f, 0.2f, 0.0f, Space.Self);
        }
    }

    private void SetSqaureColours()
    {
            Colours = Colours.OrderBy(x => Random.Range(1, 100)).ToArray();
            UISquare1.color = Colours[0];
            UISquare2.color = Colours[1];
            UISquare3.color = Colours[2];     
    }


    public void PublishCode()
    {
        string codeString = $"{Code[0]}{Code[1]}{Code[2]}";
        sendCode.Invoke(codeString);
    }

    private void GenerateCode()
    {
        Code = new int[3];
        for(int i = 0; i < Code.Length; i++)
        {
            Code[i] = Random.Range(0, 10);
        }
    }

    private void spawnDigits()
    {
        SpawnedDigits = new GameObject[3];

        for (int i = 0; i < Code.Length; i++)
        {
            float x = Random.Range(0, width);
            float z = Random.Range(0, depth);
            
            GameObject number;
            switch (Code[i])
            {
                case 0:
                    number = Instantiate(zero, new Vector3(x*5, 1f, z*5), Quaternion.identity);
                    number.GetComponent<MeshRenderer>().material.SetColor("_Color", Colours[i]);
                    break;
                case 1:
                    number = Instantiate(one, new Vector3(x*5, 1f, z*5), Quaternion.identity);
                    number.GetComponent<MeshRenderer>().material.SetColor("_Color", Colours[i]);
                    break;
                case 2:
                    number = Instantiate(two, new Vector3(x*5, 1f, z*5), Quaternion.identity);
                    number.GetComponent<MeshRenderer>().material.SetColor("_Color", Colours[i]);
                    break;
                case 3:
                    number = Instantiate(three, new Vector3(x*5, 1f, z*5), Quaternion.identity);
                    number.GetComponent<MeshRenderer>().material.SetColor("_Color", Colours[i]);
                    break;
                case 4:
                    number = Instantiate(four, new Vector3(x*5, 1f, z*5), Quaternion.identity);
                    number.GetComponent<MeshRenderer>().material.SetColor("_Color", Colours[i]);
                    break;
                case 5:
                    number = Instantiate(five, new Vector3(x*5, 1f, z*5), Quaternion.identity);
                    number.GetComponent<MeshRenderer>().material.SetColor("_Color", Colours[i]);
                    break;
                case 6:
                    number = Instantiate(six, new Vector3(x*5, 1f, z*5), Quaternion.identity);
                    number.GetComponent<MeshRenderer>().material.SetColor("_Color", Colours[i]);
                    break;
                case 7:
                    number = Instantiate(seven, new Vector3(x*5, 1f, z*5), Quaternion.identity);
                    number.GetComponent<MeshRenderer>().material.SetColor("_Color", Colours[i]);
                    break;
                case 8:
                    number = Instantiate(eight, new Vector3(x*5, 1f, z*5), Quaternion.identity);
                    number.GetComponent<MeshRenderer>().material.SetColor("_Color", Colours[i]);
                    break;
                default:
                    number = Instantiate(nine, new Vector3(x*5, 1f, z*5), Quaternion.identity);
                    number.GetComponent<MeshRenderer>().material.SetColor("_Color", Colours[i]);
                    break;

            }
            SpawnedDigits[i] = (number);
        }
    }

    public void SetMazeSizes(int width, int depth)
    {
        this.width = width;
        this.depth = depth;
    }
}
