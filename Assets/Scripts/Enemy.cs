using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int defaultSpeed = 15;
    [SerializeField] private int damage = 20;
    [SerializeField] private float repulsiveForce = 20;
    public int Speed { get; private set; }
    private float dazedTime;
    public float startDazedTime = 1;

    void Update()
    {
        if (dazedTime <= 0)
        {
            Speed = defaultSpeed;
        }
        else
        {
            Speed = 0;
            dazedTime -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
            Attack(other.collider);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            Attack(other);
    }

    private void Attack(Collider2D other)
    {
        dazedTime = startDazedTime;
        other.GetComponent<PlayerHealth>().TakeDamage(damage);
        var direction = other.transform.position - transform.position;
        direction.Normalize();
        direction.y = 1;
        other.GetComponent<Rigidbody2D>().AddForce(direction * repulsiveForce, ForceMode2D.Impulse);
    }
}
