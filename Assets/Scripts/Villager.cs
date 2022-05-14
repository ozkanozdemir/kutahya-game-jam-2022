using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Villager : MonoBehaviour
{
    [SerializeField] private GameObject pressEText;
    
    private GameSession _gameSession;
    
    private bool _playerTouching;

    private void Awake()
    {
        _gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            _playerTouching = true;
            pressEText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            _playerTouching = false;
            pressEText.SetActive(false);
        }
    }
    
    private void OnEButton(InputValue value)
    {
        if (_playerTouching)
        {
            // Rehine kurtarıldı
            
            // Objeyi 3 saniye sonra yok et
            Destroy(gameObject, 3f);
        }
    }
}
