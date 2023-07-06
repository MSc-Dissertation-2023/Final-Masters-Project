using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletePopup : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true);
        GameEvents.NotifyPaused();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void proceed()
    {
        gameObject.SetActive(false);
        GameEvents.NotifyUnpaused();
        Managers.Mission.GoToNext();
    }

    
}
