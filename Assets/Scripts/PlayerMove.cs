using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    public float JumpForce = 15f, Speed = 15f, CheckRadius;
    private Transform groundCheck;
    public LayerMask whatIsGround;
    private Camera camera;
    private GameObject body;
    private Animator bodyAnimator;
    private CameraFollow cameraFollow;
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        body = GameObject.Find("Body");
        camera = FindObjectOfType<Camera>();
        camera.GetComponent<CameraFollow>().FindPlayer();
        bodyAnimator = body.GetComponentInChildren<Animator>();
        groundCheck = GameObject.Find("GroundCheck").transform;
        cameraFollow = camera.GetComponent<CameraFollow>();
    }

    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
        RevertLogic();
    }

    private void RevertLogic()
    {
        if (Input.mousePosition.x < Screen.width / 2 && body.transform.rotation.y != 180)
        {
            body.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            cameraFollow.faceLeft = true;
        }
        else
        {
            body.transform.rotation = Quaternion.Euler(Vector3.zero);
            cameraFollow.faceLeft = false;
        }
    }
    
    private void MovementLogic()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        if(horizontalAxis != 0) bodyAnimator.SetBool("IsWalking", true);
        else bodyAnimator.SetBool("IsWalking", false);
        Vector2 movement = new Vector2(horizontalAxis * Speed, rb.velocity.y);
        if (Math.Abs(horizontalAxis) > 0)
            rb.velocity = movement;
    }

    private void JumpLogic()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, whatIsGround);
        if (Input.GetAxis("Jump") > 0 && isGrounded)
                rb.velocity = Vector2.up * JumpForce;
    }
}
