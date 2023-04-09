using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip gameOverSound;
    public AudioClip pointUpSound;

    AudioSource mainMusicAudioSource;
    GameObject mainMusicAudioGameObject;

    public static MusicManager Instance = null;

    private void Start()
    {
        mainMusicAudioGameObject = GameObject.Find("Music Manager");
        if (mainMusicAudioGameObject != null)
        {
            mainMusicAudioSource = mainMusicAudioGameObject.GetComponent<AudioSource>();
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayGameOverSound()
    {
        audioSource.clip = gameOverSound;
        audioSource.Play();
    }

    public void PlayPointUpSound()
    {
        audioSource.clip = pointUpSound;
        audioSource.Play();
    }

    public void PauseMainMusic()
    {
        mainMusicAudioSource.Pause();
    }
}
