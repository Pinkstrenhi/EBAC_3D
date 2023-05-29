using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timeToDestroy = 1f;
    public int damageAmount = 1;
    public float speedProjectile = 50f;
    private void Awake()
    {
        Destroy(gameObject,timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * speedProjectile));
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}