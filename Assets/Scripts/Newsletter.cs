using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Newsletter : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    
    private bool _playerTouching;
    private bool _canvasToggle;
    private GameObject _toggleNewsletterText;

    private void Awake()
    {
        _toggleNewsletterText = GameObject.Find("ToggleNewsletterText");
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            _playerTouching = true;

            if (_toggleNewsletterText != null)
            {
                _toggleNewsletterText.SetActive(true);   
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            _playerTouching = false;
            _canvasToggle = false;
            canvas.SetActive(_canvasToggle);
            if (_toggleNewsletterText != null)
            {
                _toggleNewsletterText.SetActive(false);   
            }
        }
    }
    
    private void OnToggleNewsLetter(InputValue value)
    {
        if (_playerTouching)
        {
            _canvasToggle = !_canvasToggle;
            canvas.SetActive(_canvasToggle);
        }
    }
}
