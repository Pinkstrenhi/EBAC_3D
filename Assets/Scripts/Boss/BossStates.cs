using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

namespace Boss
{
    public class BossStateBase : StateBase
    {
        protected BossBase _bossBase;
        public override void OnStateEnter(params object[] objects)
        {
            base.OnStateEnter(objects);
            _bossBase = (BossBase)objects[0];
        }
    }

    public class BossStateInit : BossStateBase
    {
        public override void OnStateEnter(params object[] objects)
        {
            base.OnStateEnter(objects);
            _bossBase.StartAnimation();
            Debug.Log("Boss: " + _bossBase);
        }
    }
    public class BossStateWalk : BossStateBase
    {
        public override void OnStateEnter(params object[] objects)
        {
            base.OnStateEnter(objects);
            _bossBase.GoToRandomPoint(OnArrive);
            Debug.Log("Boss: " + _bossBase);
        }
        private void OnArrive()
        {
            _bossBase.SwitchState(BossAction.Attack);
        }
    }
    public class BossStateAttack : BossStateBase
    {
        public override void OnStateEnter(params object[] objects)
        {
            base.OnStateEnter(objects);
            _bossBase.StartAttack(EndAttacks);
            Debug.Log("Boss: " + _bossBase);
        }

        private void EndAttacks()
        {
            _bossBase.SwitchState(BossAction.Walk);
        }
    }
}
