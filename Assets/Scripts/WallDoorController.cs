using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallDoorController : MonoBehaviour
{
    public GameObject[] enemies;
    public Sprite openedSprite;
    public int nextScene;
    public bool isPerehod;
    private int countOfEnemy;
    private bool isOpened;
    void Start()
    {
        countOfEnemy = enemies.Length;
        if (isPerehod)
            nextScene = Player.NextScene;
    }

    void Update()
    {
        if (!isOpened)
        {
            var enemyDies = 0;
            foreach (var enemy in enemies)
                if (enemy.Equals(null))
                    enemyDies++;
            if (enemyDies == countOfEnemy)
            {
                isOpened = true;
                GetComponent<SpriteRenderer>().sprite = openedSprite;
                GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.Health = other.GetComponent<PlayerHealth>().health;
            Player.Patrons = other.GetComponent<Gun>().patronCount;
            Player.NextScene = nextScene;
            Player.isChanged = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex == 1 ? nextScene : 1);
        }
    }
}
