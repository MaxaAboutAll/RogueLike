using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paltform : MonoBehaviour
{
    private PlatformEffector2D effector;
    private float waitTime;
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
            StartCoroutine(RestoreRotation());
        
        if (Input.GetKey(KeyCode.S))
            effector.rotationalOffset = 180f;

        if (Input.GetKey(KeyCode.Space))
            effector.rotationalOffset = 0f;
    }

    private IEnumerator RestoreRotation()
    {
        yield return new WaitForSeconds(0.3f);
        effector.rotationalOffset = 0f;
    }
}
