using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
   
    [SerializeField] private int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        Debug.Log("LogicScript Start");
        initializeGame();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        audioManager.PlaySFX(audioManager.score);
    }

    public void initializeGame()
    {
        Debug.Log("Initializing Game");
        playerScore = 0;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
       gameOverScreen.SetActive(true);
    }

}
