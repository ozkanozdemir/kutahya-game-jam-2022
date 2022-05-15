using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int playerLives = 999;
    [SerializeField] private int powerUpAmount = 3;
    [SerializeField] private int score;
    [SerializeField] private int powerUp;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI powerUpText;
    [SerializeField] private Canvas canvas;

    private bool _powerUpFulled;

    private void Awake()
    {
        var numGameSessions = FindObjectsOfType<GameSession>().Length;
        
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
        powerUpText.text = powerUp.ToString();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.StartsWith("Level"))
        {
            canvas.gameObject.SetActive(true);
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            Invoke("ResetGameSession", 1f);
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
    
    public void AddToPowerUp(int value)
    {
        powerUpAmount = Mathf.Max(powerUp - value, 0);
        powerUp += value;
        powerUpText.text = powerUp.ToString();
    }

    public void SavedVillager()
    {
        AddToPowerUp(1);
    }
    
    public void ResetScore()
    {
        score += 0;
        scoreText.text = score.ToString();
    }
    
    private void TakeLife()
    {
        playerLives--;
        
        Invoke("ResetSceneSession", 1f);
        
        livesText.text = playerLives.ToString();
    }

    private void ResetSceneSession()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        score = 0;
        powerUp = 0;
        scoreText.text = score.ToString();
        scoreText.text = powerUp.ToString();
        
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
