using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D _rb;
    private float speed;
    public float PlayerRange = 3f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {        
        speed = GetComponent<Enemy>().Speed;
        if (Vector3.Distance(player.transform.position, transform.position) < PlayerRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
