using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Newsletter : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject pressEText;

    private AudioSource _audioSource;
    private AudioSource _soundControllerAudioSource;

    private bool _playerTouching;
    private bool _canvasToggle;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _soundControllerAudioSource = GameObject.Find("SoundController").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleNewspaper();
        }
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
            _canvasToggle = false;
            canvas.SetActive(_canvasToggle);
            pressEText.SetActive(false);
        }
    }
    
    private void OnEButton(InputValue value)
    {
        ToggleNewspaper();
    }

    private void ToggleNewspaper()
    {
        if (_playerTouching)
        {
            _canvasToggle = !_canvasToggle;
            canvas.SetActive(_canvasToggle);
            
            if (_canvasToggle)
            {
                _soundControllerAudioSource.volume = 0.3f;
                _audioSource.Play();
            }
            else
            {
                _soundControllerAudioSource.volume = 1f;
                _audioSource.Stop();
            }   
        }
    }
}
