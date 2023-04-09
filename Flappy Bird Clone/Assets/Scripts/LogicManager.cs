using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    //public AudioClip pointUp;
    AudioSource pointUpAudioSource;
    GameObject pointUpAudioGameObject;

    AudioSource gameOverAudioSource;
    GameObject gameOverAudioGameObject;

    AudioSource mainMusicAudioSource;
    GameObject mainMusicAudioGameObject;

    private void Start()
    {
        pointUpAudioGameObject = GameObject.Find("Point Up Audio");
        if (pointUpAudioGameObject != null)
        pointUpAudioSource = pointUpAudioGameObject.GetComponent<AudioSource>();

        gameOverAudioGameObject = GameObject.Find("Game Over Audio");
        if (gameOverAudioGameObject != null)
        gameOverAudioSource = gameOverAudioGameObject.GetComponent<AudioSource>();

        mainMusicAudioGameObject = GameObject.Find("Main Music");
        if (mainMusicAudioGameObject != null)
        mainMusicAudioSource = mainMusicAudioGameObject.GetComponent<AudioSource>();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        playPointUpSound();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        pauseGameMainMusic();
        playGameOverSound();
    }

    public void playPointUpSound()
    {
        pointUpAudioSource.Play();
    }

    public void playGameOverSound()
    {
        gameOverAudioSource.Play();
    }

    public void pauseGameMainMusic()
    {
        mainMusicAudioSource.Pause();
    }
}
