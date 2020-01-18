using System.Collections;
using UnityEngine;

public class SkeletonEnemy : MonoBehaviour
{
    [SerializeField] private GameObject Wave;
    private GameObject player;
    private float speed;
    private Enemy enemyComponent;
    private Animator animator;
    public Transform wavesSpawnPoint;
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
   
    private void SpawnWaves()
    {
        var spawnPos = wavesSpawnPoint.transform.position;
        var firstWave = Instantiate(Wave, spawnPos, new Quaternion());
        var secondWave = Instantiate(Wave, spawnPos, new Quaternion());
        firstWave.GetComponent<Wave>().dir = new Vector2(-1, 0);
        secondWave.GetComponent<Wave>().dir = new Vector2(1, 0);
    }
}
