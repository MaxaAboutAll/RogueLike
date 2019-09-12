using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttak : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray2D myRay2D = new Ray2D();
        var position = transform.position;
        myRay2D.origin = new Vector2(position.x + 0.9f, position.y);
        myRay2D.direction = new Vector2(position.x + 15, position.y);
        RaycastHit2D myHit = Physics2D.Raycast(myRay2D.origin, myRay2D.direction);
        Debug.DrawRay(myRay2D.origin, myRay2D.direction, Color.yellow);
        if (myHit.collider != null)
        {
            Debug.Log(myHit.collider.name);
        }
    }
}
