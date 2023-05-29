using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase projectileBase;
    public Transform positionToShoot;
    public float timeBetweenShoot = 0.2f;
    private Coroutine _currentCoroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _currentCoroutine = StartCoroutine(nameof(StartShoot));
        }
        else if(Input.GetKeyUp(KeyCode.Q))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(nameof(StartShoot));
            }
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
           Shoot();
           yield return new WaitForSeconds(timeBetweenShoot);
        }
    }
    private void Shoot()
    {
        var projectile = Instantiate(projectileBase);
        projectile.transform.position = positionToShoot.position; 
        projectile.transform.rotation = positionToShoot.rotation; 
    }
}
