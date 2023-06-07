using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class HealthBase : MonoBehaviour
{
    public float startLife = 10f;
    public float timeToDestroy = 3f;
    public bool destroyOnKill = false;
    public Action<HealthBase> onDamage;
    public Action<HealthBase> onKill;
    [SerializeField] private float _currentLife;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }
    protected void ResetLife()
    {
        _currentLife = startLife;
    }
    protected virtual void Kill()
    {
        if (destroyOnKill)
        {
            Destroy(gameObject, timeToDestroy);
        }
        onKill?.Invoke(this);
    }
    [Button]
    public void DamageTest()
    {
        Damage(5f);
    }
    public void Damage(float damage)
    { 
        _currentLife -= damage;
        if (_currentLife <= 0)
        {
            Kill();
        }
        onDamage?.Invoke(this);
    }
}
