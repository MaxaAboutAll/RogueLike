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
            var position = bulletStartPosition.position.normalized;
            var mousePos = camera.ScreenToWorldPoint(Input.mousePosition).normalized;
            GameObject bullet = Instantiate(bulletPrefab, bulletStartPosition.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Speed = speed;
//            bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Time.deltaTime * speed * (mousePos - position), ForceMode2D.Impulse);
        }
    }
}
