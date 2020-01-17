using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health = 100;
    [SerializeField] private int defaultSpeed = 15;
    [SerializeField] private int damage = 20;
    [SerializeField] private float repulsiveForce = 20;
    public int Speed { get; private set; }
    private float dazedTime;
    public float startDazedTime = 1;
    private bool isDeath = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (dazedTime <= 0)
        {
            Speed = defaultSpeed;
            animator?.SetInteger("CountOfAttack", 0);
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
        StartCoroutine(HasAttacked());
        if (health <= 0)
            StartCoroutine(MakeDeath());
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
        animator?.Play("SkeletonAttack");
        other.GetComponent<PlayerHealth>().TakeDamage(damage);
        var direction = other.transform.position - transform.position;
        direction.Normalize();
        direction.y = 1;
        other.GetComponent<Rigidbody2D>().AddForce(direction * repulsiveForce, ForceMode2D.Impulse);
    }
    private IEnumerator HasAttacked()
    {
        animator?.Play("SkeletonHit");
        yield return new WaitForSeconds(1f);    
        animator?.Play("SkeletonIdle");

    }

    private IEnumerator MakeDeath()
    {
        if (!isDeath)
        {
            isDeath = true;
            animator?.Play("SkeletonDeath");
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<BoxCollider2D>().size = new Vector2(0.24f, 0.03f);
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}
