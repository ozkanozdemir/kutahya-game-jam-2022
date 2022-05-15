using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int playerLives = 999;
    [SerializeField] private int powerUpAmount = 3;
    [SerializeField] private int score;
    [SerializeField] private int powerUp;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI powerUpText;
    [SerializeField] private Slider powerUpSlider;
    [SerializeField] private Canvas canvas;

    private bool _powerUpFull;

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
        powerUpText.text = powerUp.ToString();
        powerUpSlider.maxValue = powerUpAmount;
        UpdateSliderValue();
    }
    
    private void UpdateSliderValue() {
        powerUpSlider.value = 3 - powerUpAmount;
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
        powerUpText.text = score.ToString();
    }
    
    public void AddToPowerUp(int value)
    {
        powerUpAmount = Mathf.Max(powerUpAmount - value, 0);
        
        if (powerUpAmount <= 0)
        {
            _powerUpFull = true;
        }
        
        powerUp += value;
        powerUpText.text = powerUp.ToString();
        UpdateSliderValue();
    }

    public bool GetPowerUpFull()
    {
        return _powerUpFull;
    }
    
    public void SetPowerUpFull(bool value)
    {
        if (!value)
        {
            powerUpAmount = 3;
            UpdateSliderValue();
        }
        
        _powerUpFull = value;
    }

    public void SavedVillager()
    {
        AddToPowerUp(1);
    }
    
    public void ResetScore()
    {
        score += 0;
        powerUpText.text = powerUp.ToString();
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
        powerUpText.text = powerUp.ToString();
        
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
