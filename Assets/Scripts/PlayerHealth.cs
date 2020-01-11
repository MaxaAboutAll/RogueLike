using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 4;
    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private Sprite fullHeart, emptyHeart;
    
    private void Start()
    {
        for (int i = 0; i < hearts.Length; i++)
        {            
            hearts[i].enabled = true;
            if (i < health)
                hearts[i].sprite = fullHeart;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
        hearts[health].sprite = emptyHeart;
    }

    public void TakeHealth(int addHealth)
    {
        if (health < 4)
        {
            hearts[health].sprite = fullHeart;
            health += addHealth;
        }
    }
}
