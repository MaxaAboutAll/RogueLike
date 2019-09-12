using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPos;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public LayerMask whatIsEnemies;
    public int damage;
    public float attackRadius;
    
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Collider2D[] enemiesToDamage =
                    Physics2D.OverlapCircleAll(attackPos.position, attackRadius, whatIsEnemies);
                foreach (var enemy in enemiesToDamage)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
            timeBtwAttack -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position, attackRadius);        
    }
}