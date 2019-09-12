using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int defaultSpeed;
    private int speed;
    private float dazedTime;
    public float startDazedTime;
    
    void Start()
    {
    }

    void Update()
    {
        if (dazedTime <= 0)
        {
            speed = defaultSpeed;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        health -= damage;
        Debug.Log("Damage TAKEN");
        if (health <= 0)
            Destroy(gameObject);
    }
}
