using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;

    private Rigidbody2D _rigidbody;

    private float _xSpeed;
    
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _xSpeed = speed;
    }

    // Update is called once per frame
    private void Update()
    {
        _rigidbody.velocity = new Vector2(_xSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.tag.Equals("Enemy"))
        {
            Destroy(col.gameObject );
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (!col.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);   
        }
    }
}
