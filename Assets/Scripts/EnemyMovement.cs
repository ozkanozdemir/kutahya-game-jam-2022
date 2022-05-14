using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        _rigidbody.velocity = new Vector2(moveSpeed, 0f);
        
        if (Mathf.Abs(_rigidbody.velocity.x) > 0)
        {
            _animator.SetInteger("Animate", 2);
        }
        else
        {
            _animator.SetInteger("Animate", 0);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Wall"))
        {
            moveSpeed = -moveSpeed;
            FlipEnemyFacing();   
        }
    }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(_rigidbody.velocity.x)), 1f);   
    }
}
