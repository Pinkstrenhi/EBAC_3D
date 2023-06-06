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
        
    }
}
