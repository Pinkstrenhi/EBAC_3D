using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestructableBase : MonoBehaviour
{
    public HealthBase healthBase;
    public float tweenShake = 0.1f;
    public int tweenForce = 1;

    private void Awake()
    {
        OnValidate();
        healthBase.onDamage += OnDamage;
    }

    private void OnValidate()
    {
        if (healthBase == null)
        {
            healthBase = GetComponent<HealthBase>();
        }
    }

    private void OnDamage(HealthBase hb)
    {
        transform.DOShakeScale(tweenShake,Vector3.up/2,tweenForce);
    }
}
