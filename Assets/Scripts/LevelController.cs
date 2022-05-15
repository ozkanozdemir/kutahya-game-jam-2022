using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int targetVillager;
    
    private SceneController _sceneController;

    private int _savedVillager;

    private void Awake()
    {
        _sceneController = FindObjectOfType<SceneController>();
    }

    public void SaveVillager()
    {
        _savedVillager++;

        if (_savedVillager >= targetVillager)
        {
            _sceneController.NextLevel();
        }
    }
}
