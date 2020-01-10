using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : MonoBehaviour
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
        speed = enemyComponent.Speed;
        if (player && Vector3.Distance(player.transform.position, transform.position) < PlayerRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            if((player.transform.position - transform.position).x > 0)
                FlipSprite(false);
            else
                FlipSprite(true);
        }
    }

    private void FlipSprite(bool toLeft)
    {
        if(!toLeft)
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        else
            transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
