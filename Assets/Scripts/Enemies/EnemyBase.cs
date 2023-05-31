using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        public float startLife = 10f;
        [SerializeField]private float _currentLife;
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
            Destroy(gameObject);
        }

        public void OnDamage(float damage)
        {
            _currentLife -= damage;
            if (_currentLife <= 0)
            {
                Kill();
            }
        }

        #region Animations

            private void StartAnimation()
            {
                transform.DOScale(0,durationAnimation).SetEase(easeAnimation).From();
            }

        #endregion
    }
}
