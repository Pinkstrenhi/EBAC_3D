using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Collider> colliders;
    public Animator animator;
    public CharacterController characterController;
    public float speedMovement = 25f;
    public float speedRotation = 300f;
    public float gravity = 9.8f;
    private float _speedVertical = 0f;
    public float speedJump = 15f;
    [Header("Run Setup")] 
        public KeyCode keyRun = KeyCode.LeftShift;
        public float speedRun = 1.5f;
    [Header("Flash")] 
        public List<FlashColor> flashColors;
    [Header("Life")]
        public HealthBase healthBase;
    private bool _alive = true;

    private void Awake()
    {
        OnValidate();
        healthBase.onDamage += Damage;
        healthBase.onKill += OnKill;
    }
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
    
    #region Life

        public void Damage(HealthBase healthBase)
        {
            flashColors.ForEach(i => i.Flash());
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
               colliders.ForEach(i => i.enabled = false);
           }
       }

    #endregion
}
