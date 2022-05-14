using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Newsletter : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject toggleNewsletterText;
    
    private bool _playerTouching;
    private bool _canvasToggle;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            _playerTouching = true;
            toggleNewsletterText.SetActive(true);
            Debug.Log("1");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            _playerTouching = false;
            _canvasToggle = false;
            canvas.SetActive(_canvasToggle);
            toggleNewsletterText.SetActive(false);
            Debug.Log("2");
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
