using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDoorController : MonoBehaviour
{
    public GameObject[] enemies;
    public Sprite openedSprite;
    private int countOfEnemy;
    private bool isOpened;
    void Start()
    {
        countOfEnemy = enemies.Length;
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
                GetComponent<BoxCollider2D>().size = Vector2.zero;
            }
        }   
    }
}
