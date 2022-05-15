using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Villager : MonoBehaviour
{
    [SerializeField] private GameObject pressEText;
    [SerializeField] private GameObject canvas;
    
    private GameSession _gameSession;
    private Animator _animator;
    
    private bool _playerTouching;
    private bool _isSaved;

    private void Awake()
    {
        _gameSession = FindObjectOfType<GameSession>();
        _animator = GetComponent<Animator>();
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
        if (_playerTouching && _gameSession != null && !_isSaved)
        {
            _isSaved = true;
            _gameSession.SavedVillager();
            
            _animator.SetInteger("Animate", 3);
            canvas.SetActive(true);
            
            pressEText.SetActive(false);
            
            Destroy(gameObject, 3f);
        }
    }
}
