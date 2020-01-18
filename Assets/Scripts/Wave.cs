using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public Vector2 dir;
    public float speed = 15f;
    private bool isFlipped;
    void Update()
    {
        transform.position += new Vector3(dir.normalized.x * speed * Time.deltaTime, 0) ;
        if (dir.x > 0 && !isFlipped)
            FlipSprite(true);
        else
            FlipSprite(false);
    }
    
    private void FlipSprite(bool toLeft)
    {
        if(!toLeft)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        isFlipped = true;
    }
}
