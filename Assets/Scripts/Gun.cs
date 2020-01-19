using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.UI;
using Random = System.Random;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletStartPosition;
    private Light2D fireLight;
    [SerializeField]
    private float speed = 100;
    [SerializeField]
    private float fireLightMilliseconds = 50;
    [SerializeField]
    private int patronCount = 4;
    [SerializeField]
    public Sprite[] sprites;
    
    private Image patronsUi;
    private bool isRecharging = false;

    private void Start()
    {
        patronsUi = GameObject.Find("PatronsUI").GetComponent<Image>();
        fireLight = GameObject.Find("FireLight").GetComponent<Light2D>();
        fireLight.enabled = false;
        fireLightMilliseconds /= 1000;
        SwitchPatronsUi();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            if (patronCount > 0)
            {
                StartCoroutine(ShowFireLight());
                isRecharging = false;
                var bulletPos = bulletStartPosition.position;
                GameObject bullet = Instantiate(bulletPrefab, bulletPos, new Quaternion());
                bullet.GetComponent<Bullet>().Speed = speed;
                patronCount--;
                SwitchPatronsUi();
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && !isRecharging)
        {
            isRecharging = true;
            StartCoroutine(Recharge());
        }
    }

    private void SwitchPatronsUi()
    {
        patronsUi.sprite = sprites[patronCount];
    }

    private IEnumerator Recharge()
    {
        while (isRecharging && patronCount < 4)
        {
            yield return new WaitForSeconds(0.5f);
            if(!isRecharging || patronCount >= 4) break;
            patronCount++;
            SwitchPatronsUi();
        }
    }

    private IEnumerator ShowFireLight()
    {
        fireLight.enabled = true;
        yield return new WaitForSeconds(fireLightMilliseconds);
        fireLight.enabled = false;
    }
}
