using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 1;
    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject scoreObject;

    [SerializeField] private TMP_Text highScoreText;
    public const string HighScoreKey = "HighScore";


    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();

        int highScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        highScoreText.text = $"High Score: {highScore}";
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives < 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    private void OnDestroy()
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }
    }


    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ResetGameSession()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Destroy(gameObject);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        scoreObject.SetActive(false);
    }
}
