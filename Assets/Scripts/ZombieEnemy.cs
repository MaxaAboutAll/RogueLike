using System.Collections;
using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    private GameObject player;
    private float speed;
    private Enemy enemyComponent;
    private Animator animator;
    public float PlayerRange = 3f;
    private int countOfAttack = 0;
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
            if (Mathf.Abs(dir.x) < 2.5f)
            {
                countOfAttack++;
                // animator?.SetInteger("CountOfAttack", countOfAttack);
                // StartCoroutine(HasAttacked());
            }
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
    // private IEnumerator HasAttacked()
    // {
    //     yield return new WaitForSeconds(0.55f);
    //     if (countOfAttack > 0)
    //     {
    //         countOfAttack = 0;
    //         animator?.SetInteger("CountOfAttack", countOfAttack);
    //     }                
    // }
}
