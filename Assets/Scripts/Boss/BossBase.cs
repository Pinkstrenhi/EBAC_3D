using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;
using NaughtyAttributes;
using DG.Tweening;
using Random = UnityEngine.Random;

namespace Boss
{
    public enum BossAction
    {
        Init,
        Idle,
        Walk, 
        Attack
    }
    public class BossBase : MonoBehaviour
    {
        public float speed = 5f;
        public List<Transform> waypoints;
        [Header("Animation")] 
            public float durationAnimation = 0.5f;
            public Ease easeAnimation = Ease.OutBack;
        private StateMachine<BossAction> _stateMachine;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _stateMachine = new StateMachine<BossAction>();
            _stateMachine.Init();
            _stateMachine.RegisterStates(BossAction.Init, new BossStateInit());
            _stateMachine.RegisterStates(BossAction.Walk, new BossStateWalk());
        }

        #region Movement

            [Button]
            public void GoToRandomPoint()
            {
                StartCoroutine(CoroutineGoToPoint(waypoints[Random.Range(0,waypoints.Count)]));
            }

            IEnumerator CoroutineGoToPoint(Transform point)
            {
                while (Vector3.Distance(transform.position,point.position) > 1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position,
                        point.transform.position, Time.deltaTime * speed);
                    yield return new WaitForEndOfFrame();
                }
            }

        #endregion
        #region Animation

            public void StartAnimation()
            {
                transform.DOScale(0,durationAnimation).SetEase(easeAnimation).From();
            }

        #endregion
        #region Debug
            [Button]
            private void SwitchInit()
            {
                SwitchState(BossAction.Init);
            }
            [Button]
            private void SwitchWalk()
            {
                SwitchState(BossAction.Walk);
            }

        #endregion

        #region State Machine

            public void SwitchState(BossAction state)
            {
                _stateMachine.SwitchStates(state,this);
            }

        #endregion
    }
}
