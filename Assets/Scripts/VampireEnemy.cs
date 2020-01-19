using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireEnemy : MonoBehaviour
{
    private GameObject player;
    private float speed;
    private Enemy enemyComponent;
    private Animator animator;
    public float PlayerRange = 3f;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemyComponent = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
        animator.SetInteger("Health", enemyComponent.health);
    }

    void FixedUpdate()
    {        
        MovementLogic();
    }

    private void FlipSprite(bool toLeft)
    {
        if(!toLeft)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

    }

    private void MovementLogic()
    {
        speed = enemyComponent.Speed;
        var enemyPos = transform.position;
        if (player && Vector3.Distance(player.transform.position, enemyPos) < PlayerRange)
        {
            var dir = player.transform.position - enemyPos;
            animator.SetInteger("Speed", (int)dir.x);
            transform.position += new Vector3(dir.normalized.x * speed * Time.deltaTime, 0) ;
            if (dir.x > 0)
                FlipSprite(false);
            else
                FlipSprite(true);
        }
        else
            animator.SetInteger("Speed", 0);
    }
}
