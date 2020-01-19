using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public GameObject[] enemies;
    public Sprite openedSprite;
    public int nextScene;
    private int countOfEnemy;
    private bool isOpened;
    void Start()
    {
        countOfEnemy = enemies.Length;
    }

    void Update()
    {
        // if (!isOpened)
        // {
        //     var enemyDies = 0;
        //     foreach (var enemy in enemies)
        //     if (enemy.Equals(null))
        //         enemyDies++;
        //     if (enemyDies == countOfEnemy)
        //     {
        //         isOpened = true;
        //         GetComponent<SpriteRenderer>().sprite = openedSprite;
        //     }
        // }   
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.Health = other.GetComponent<PlayerHealth>().health;
            Player.Patrons = other.GetComponent<Gun>().patronCount;
            Player.NextScene = nextScene;
            SceneManager.LoadScene(1);
        }
    }
}
