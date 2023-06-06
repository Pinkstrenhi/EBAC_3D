using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

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
        private StateMachine<BossAction> _stateMachine;

        private void Init()
        {
            _stateMachine = new StateMachine<BossAction>();
            _stateMachine.Init();
        }

        #region State Machine

            public void SwitchState(BossAction state)
            {
                _stateMachine.SwitchStates(state,this);
            }

        #endregion
    }
}
