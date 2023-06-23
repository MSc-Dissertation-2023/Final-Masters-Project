using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * A class to track score and display in HUD
 */
public class UIController : MonoBehaviour
{
    //Score label
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] TMP_Text healthLabel;
    private int score;

    void Start()
    {
        score = 0;
        scoreLabel.text = score.ToString();
    }
    public void OnEnemyKilled()
    {
        score += 1;
        scoreLabel.text = score.ToString();
    }

    public void UpdateHealthDisplay(int health)
    {
        healthLabel.text = $"HP: {health}";

    }
}
