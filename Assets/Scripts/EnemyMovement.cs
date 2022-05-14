using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    
    private Collider2D _collider2DForPlayer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _fire = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider2DForPlayer = GetComponent<BoxCollider2D>();
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
    
    private IEnumerator Fire() 
    {
        while (_fire)
        {
            Debug.Log("Ateş edildi");
            GameObject bulletObject = Instantiate(bullet, gun.position, transform.rotation);
            bulletObject.GetComponent<EnemyBullet>().enemy = gameObject;
            yield return new WaitForSeconds(1f);
        }
    } 

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Wall"))
        {
            moveSpeed = -moveSpeed;
            FlipEnemyFacing();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            moveSpeed = 0;
            _fire = true;
            StartCoroutine(Fire());
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            _fire = false;
            StopAllCoroutines();
            moveSpeed = 1;
            FlipEnemyFacing();
        }
    }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector2((Mathf.Sign(moveSpeed)), 1f);   
    }
}
