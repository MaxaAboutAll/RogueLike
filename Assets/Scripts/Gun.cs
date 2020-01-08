using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletStartPosition;
    [SerializeField]
    private float speed = 100;

    private Camera camera;

    private void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletStartPosition.position, new Quaternion());
            bullet.GetComponent<Bullet>().Speed = speed;
        }
    }
}
