using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D _rb;
    private bool _isGrounded;
    public float JumpForce = 15f, Speed = 15f;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        _rb = player.GetComponentInChildren<Rigidbody2D>();
        _rb.fixedAngle = true;
    }

    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }
    
    private void MovementLogic()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        
        Vector2 movement = new Vector2(horizontalAxis * Speed, _rb.velocity.y);
        if (Math.Abs(horizontalAxis) > 0)
            _rb.velocity = movement;
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
                _rb.AddForce(Vector2.up * JumpForce);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        IsGroundedUpdate(collision, true);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        IsGroundedUpdate(collision, false);
    }

    private void IsGroundedUpdate(Collision2D collision, bool value)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = value;
        }
    }
}
