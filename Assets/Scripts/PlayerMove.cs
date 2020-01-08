using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _isGrounded;
    public float JumpForce = 15f, Speed = 15f;
    private Camera camera;
    private GameObject body;
    void Start()
    {
        _rb = GetComponentInChildren<Rigidbody2D>();
        body = GameObject.Find("Body");
        camera = FindObjectOfType<Camera>();
    }

    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
        RevertLogic();
    }

    private void RevertLogic()
    {
        if (Input.mousePosition.x < Screen.width/2 && body.transform.rotation.y != 180)
            body.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        else
            body.transform.rotation = Quaternion.Euler(Vector3.zero);
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
