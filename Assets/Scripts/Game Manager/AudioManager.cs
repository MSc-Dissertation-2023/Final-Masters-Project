using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    [SerializeField] AudioSource music1Source;

    [SerializeField] string scaryMusic;


    public void PlayLevelMusic()
    {
        PlayMusic(Resources.Load($"Music/{scaryMusic}") as AudioClip);
    }

    private void PlayMusic(AudioClip clip)
    {
        music1Source.clip = clip;
        music1Source.Play();
    }
    public void StopMusic()
    {
        music1Source.Stop();
    }

    
    public void Startup()
    {
        Debug.Log("Audio manager starting...");
     
        status = ManagerStatus.Started;
        
    }

    public void Start()
    {
        PlayLevelMusic();
    }

    public float soundVolume
    {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }
    public bool soundMute
    {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }

}