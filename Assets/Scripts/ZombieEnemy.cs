using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    private GameObject player;
    private float speed;
    private Enemy enemyComponent;
    public float PlayerRange = 3f;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemyComponent = GetComponent<Enemy>();
    }

    void FixedUpdate()
    {        
        MovementLogic();
    }

    private void FlipSprite(bool toLeft)
    {
        if(!toLeft)
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        else
            transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void MovementLogic()
    {
        speed = enemyComponent.Speed;
        var enemyPos = transform.position;
        if (player && Vector3.Distance(player.transform.position, enemyPos) < PlayerRange)
        {
            var dir = player.transform.position - enemyPos;
            transform.position += new Vector3(dir.normalized.x * speed * Time.deltaTime, 0) ;
            if (dir.x > 0)
                FlipSprite(false);
            else
                FlipSprite(true);
        }
    }
}
