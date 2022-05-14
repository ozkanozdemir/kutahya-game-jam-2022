using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishToMenu : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            SceneManager.LoadScene("MainMenu");

            // loads scene When player enter the trigger collider
        }
    }
}
