using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour,IDamageable
    {
        public Collider collider;
        public float startLife = 10f;
        public float timeToDestroy = 3f;
        [SerializeField]private float _currentLife;
        [SerializeField]private AnimationBase _animationBase;
        [Header("Animation")] 
            public float durationAnimation = 0.2f;
            public Ease easeAnimation = Ease.OutBack;
            public bool startAnimation = true;
        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                OnDamage(5f);
            }
        }

        protected virtual void Init()
        {
            ResetLife();
            if (startAnimation)
            {
                StartAnimation();
            }
        }

        protected void ResetLife()
        {
            _currentLife = startLife;
        }
        protected virtual void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            if (collider != null)
            {
                collider.enabled = false;
            }
            Destroy(gameObject,timeToDestroy);
            AnimationPlayByTrigger(TypeAnimation.Death);
        }

        public void OnDamage(float damage)
        {
            _currentLife -= damage;
            if (_currentLife <= 0)
            {
                Kill();
            }
        }
        public void Damage(float damage)
        {
            Debug.Log("Damage");
            OnDamage(damage); 
        }
        #region Animations

            private void StartAnimation()
            {
                transform.DOScale(0,durationAnimation).SetEase(easeAnimation).From();
            }
            public void AnimationPlayByTrigger(TypeAnimation typeAnimation)
            {
                _animationBase.AnimationPlayByTrigger(typeAnimation);
            }

        #endregion
    }
}
