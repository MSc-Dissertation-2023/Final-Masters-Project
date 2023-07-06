using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class to manager the settings popup window
 */
public class SettingsPopup : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true);
        GameEvents.NotifyPaused();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        GameEvents.NotifyUnpaused();
    }

    public void OnSensitivityChanged(float sens)
    {
        GameEvents.ChangeSensitivity(sens);
    }

    public void OnSoundToggle()
    {
        Managers.Audio.soundMute = !Managers.Audio.soundMute;
    }

    public void OnSoundValue(float volume)
    {
        Managers.Audio.soundVolume = volume;
    }
}
