using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    void Update()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
//        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (Input.mousePosition.x < Screen.width/2)
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, -angle));
        else
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
