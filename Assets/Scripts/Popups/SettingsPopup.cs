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
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Messenger.Broadcast(GameEvent.GAME_UNPAUSED);
    }

    public void OnSensitivityChanged(float sens)
    {
        Messenger<float>.Broadcast(GameEvent.SENSITIVITY_CHANGED, sens);
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
