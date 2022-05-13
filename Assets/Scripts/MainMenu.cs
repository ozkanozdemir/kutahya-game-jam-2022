using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        FindObjectOfType<GameSession>().ResetScore();
        
        SceneManager.LoadScene("Level 1");
        Destroy(gameObject);
    }
}
