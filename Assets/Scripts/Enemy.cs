using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int defaultSpeed = 15;
    public int Speed { get; private set; }
    private float dazedTime;
    public float startDazedTime;

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
}
