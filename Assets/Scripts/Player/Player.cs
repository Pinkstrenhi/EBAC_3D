using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Core.Singleton;

public class Player : Singleton<Player>
{
    public List<Collider> colliders;
    public Animator animator;
    public CharacterController characterController;
    public float speedMovement = 25f;
    public float speedRotation = 300f;
    public float gravity = 9.8f;
    private float _speedVertical = 0f;
    public float speedJump = 15f;
    public float timeToRevive = 3f;
    //public float timeToInvokeColliders = 0.1f;
    [Header("Run Setup")] 
        public KeyCode keyRun = KeyCode.LeftShift;
        public float speedRun = 1.5f;
    [Header("Flash")] 
        public List<FlashColor> flashColors;
    [Header("Life")]
        public HealthBase healthBase;
    private bool _alive = true;

    protected override void Awake()
    {
        base.Awake();
        OnValidate();
        healthBase.onDamage += Damage;
        healthBase.onKill += OnKill;
    }

    /*private void Start()
    {
        OnValidate();
        healthBase.onDamage += Damage;
        healthBase.onKill += OnKill;
    }*/

    private void OnValidate()
    {
        if (healthBase == null)
        {
            healthBase = GetComponent<HealthBase>();
        }
    }

    private void Update()
    {
        transform.Rotate(0,Input.GetAxis("Horizontal") * speedRotation * Time.deltaTime,0);
        var inputAxisVertical = Input.GetAxis("Vertical");
        var movementVertical = transform.forward * inputAxisVertical* speedMovement;
        if (characterController.isGrounded)
        {
            _speedVertical = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _speedVertical = speedJump;
            }
        }
        var isWalking = inputAxisVertical != 0;
        if (isWalking)
        {
            if (Input.GetKey(keyRun))
            {
                movementVertical *= speedRun;
                animator.speed = speedRun;
            }
            else
            {
                animator.speed = 1f;
            }
        }
        _speedVertical -= gravity * Time.deltaTime;
        movementVertical.y = _speedVertical;
        characterController.Move(movementVertical * Time.deltaTime);
        animator.SetBool("Run",isWalking);
    }
    [Button]
    public void Respawn()
    {
        if (CheckpointManager.Instance.HasCheckpoint())
        {
            transform.position = CheckpointManager.Instance.GetPositionLastCheckpoint();
        }
    }

    private void Revive()
    {
        healthBase.ResetLife();
        animator.SetTrigger("Revive");
        Respawn();
        SetColliders(true);
        _alive = true;
    }

    private void SetColliders(bool colliderState)
    {
        colliders.ForEach(i => i.enabled = colliderState);
    }
    
    #region Life

        public void Damage(HealthBase healthBase)
        {
            flashColors.ForEach(i => i.Flash());
            EffectsManager.Instance.ChangeVignette();
        }

       /* public void Damage(float damage, Vector3 direction)
        {
            Damage(damage);
        }*/
       private void OnKill(HealthBase healthBase)
       {
           if (_alive)
           {
               _alive = false;
               animator.SetTrigger("Death");
               SetColliders(false);
               Invoke(nameof(Revive),timeToRevive);
           }
       }

    #endregion
}
