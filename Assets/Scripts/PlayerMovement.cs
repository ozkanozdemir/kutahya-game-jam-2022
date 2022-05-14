using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(20f, 20f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] private AudioClip dieClip;
    
    private Vector2 _moveInput;
    private Rigidbody2D _rigidbody;
    private Animator _animator; 
    private CapsuleCollider2D _bodyCollider;
    private BoxCollider2D _feetCollider;
    private GameSession _gameSession;
    private AudioSource _audio;

    private float _gravityScaleAtStart;
    private bool _isAlive = true;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _bodyCollider = GetComponent<CapsuleCollider2D>();
        _feetCollider = GetComponent<BoxCollider2D>();
        _gravityScaleAtStart = _rigidbody.gravityScale;
        _gameSession = FindObjectOfType<GameSession>();
        _audio = FindObjectOfType<AudioSource>();
        
        _animator.SetInteger("Animate", 0);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_isAlive) { return; }
        
        Run();
        FlipSprite();
        ClimbLadder();
        CheckDie();

        // if (Mathf.Abs(_rigidbody.velocity.y) > 0 && !_animator.GetBool("isClimbing"))
        // {
        //     // _animator.SetBool("isJumping", true);
        // }
        // else
        // {
        //     // _animator.SetBool("isJumping", false);
        // }
    }

    private void OnFire(InputValue value) 
    {
        if (!_isAlive) { return; }

        GameObject bulletObject = Instantiate(bullet, gun.position, transform.rotation);
    } 
    
    private void OnMove(InputValue value)
    {
        if (!_isAlive) { return; }
        
        _moveInput = value.Get<Vector2>();
    } 

    private void OnJump(InputValue value)
    {
        if (!_isAlive) { return; }
        if (!_feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        
        if (value.isPressed)
        {
            _rigidbody.velocity += new Vector2(0f, jumpSpeed );
           
        }
    }

    private void Run()
    {
        Vector2 playerVelocity = new Vector2(_moveInput.x * runSpeed, _rigidbody.velocity.y);
        _rigidbody.velocity = playerVelocity;
        
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            _animator.SetInteger("Animate", 2);
        }
        else
        {
            _animator.SetInteger("Animate", 0);
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody.velocity.x), 1f);   
        }
    }
    
    private void ClimbLadder()
    {
        if (!_bodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            _rigidbody.gravityScale = _gravityScaleAtStart;
            return;
        }
        
        Vector2 climbVelocity = new Vector2(_rigidbody.velocity.x, _moveInput.y * climbSpeed);
        _rigidbody.velocity = climbVelocity;
        
        bool playerHasVerticalSpeed = Mathf.Abs(_rigidbody.velocity.y) > Mathf.Epsilon;
        // _animator.SetBool("isClimbing", playerHasVerticalSpeed);
        _rigidbody.gravityScale = 0f;
    }

    private void CheckDie()
    {
        if (_bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            _isAlive = false;
            // _animator.SetTrigger("Dying");
            // _rigidbody.velocity = deathKick;
            
            AudioSource.PlayClipAtPoint(dieClip, transform.position);
            
            _gameSession.ProcessPlayerDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Finish"))
        {
            SceneManager.LoadScene("Credentials");
        }
    }
}
