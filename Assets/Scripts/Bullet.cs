﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;

    private Vector2 destiantion;
    public float Speed { private get; set; }
    private float length;
    private void Start()
    {
        var camera = FindObjectOfType<Camera>();
        var position = transform.position;
        var mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        destiantion = mousePos - position;
        destiantion.Normalize();
        length = Mathf.Sqrt(destiantion.x * destiantion.x + destiantion.y * destiantion.y); 
    }

    private void Update()
    {
        Vector3 movement = new Vector2(destiantion.x/length,destiantion.y/length);
        movement.x *= Speed * Time.deltaTime;
        movement.y *= Speed * Time.deltaTime;
        transform.position += movement;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = other.collider.GetComponent<Enemy>(); 
        if(enemy != null)
            enemy.TakeDamage(damage);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>(); 
        if(enemy != null)
            enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}