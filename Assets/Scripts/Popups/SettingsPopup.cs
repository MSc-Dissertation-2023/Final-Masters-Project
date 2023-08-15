using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*
 * A class to manager the settings popup window
 */
public class SettingsPopup : MonoBehaviour
{
    [SerializeField] Slider sensitivitySlider;
    [SerializeField] Slider volumeSlider;

    public void Open()
    {
        gameObject.SetActive(true);
        GameEvents.NotifyPaused();

        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity");
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");

    }

    public void Close()
    {
        gameObject.SetActive(false);
        GameEvents.NotifyUnpaused();
    }

    public void OnSensitivityChanged(float sens)
    {
        GameEvents.ChangeSensitivity(sens);
        PlayerPrefs.SetFloat("Sensitivity", sens);
    }

    public void OnSoundToggle()
    {
        Managers.Audio.soundMute = !Managers.Audio.soundMute;
        PlayerPrefs.SetString("Sound", Managers.Audio.soundMute.ToString());
    }

    public void OnSoundValue(float volume)
    {
        Managers.Audio.soundVolume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void MainMenu()
    {
        GameObject managers = GameObject.Find("GameManager");
        Destroy(managers);
        SceneManager.LoadScene("Startup");
    }
}
