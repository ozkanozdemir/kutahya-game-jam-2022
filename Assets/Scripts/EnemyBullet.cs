using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;

    private Rigidbody2D _rigidbody;
    public GameObject enemy;

    private float _xSpeed;
    
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _xSpeed = enemy.transform.localScale.x * speed;
    }

    // Update is called once per frame
    private void Update()
    {
        _rigidbody.velocity = new Vector2(_xSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            Destroy(col.gameObject );
        }
        
        if (!col.tag.Equals("Enemy"))
        {
            Destroy(gameObject);   
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);   
        }
    }
}
