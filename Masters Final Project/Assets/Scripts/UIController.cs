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
    private int score;

    //Declare which method responds to enemy killed event
    void OnEnable()
    {
        Messenger.AddListener(GameEvent.ENEMY_KILLED, OnEnemyKilled);
    }
    //Remove lister when oblect is deactivated
    void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_KILLED, OnEnemyKilled);
    }

    void Start()
    {
        score = 0;
        scoreLabel.text = score.ToString();
    }
    private void OnEnemyKilled()
    {
        score += 1;
        scoreLabel.text = score.ToString();
    }
}
