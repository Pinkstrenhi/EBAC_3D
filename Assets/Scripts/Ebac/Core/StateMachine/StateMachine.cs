using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UIElements;

public class Test
{
   public enum typeTest
   {
      Idle
   }

   public void TheRealTest()
   {
      StateMachine<typeTest> stateMachine = new StateMachine<typeTest>();
      stateMachine.RegisterStates(Test.typeTest.Idle, new StateBase());
   }
}

public class StateMachine<T> where T : System.Enum
{
   public Dictionary<T, StateBase> DictionaryState;
   private StateBase _currentState;
   public float timeToStartGame = 1f;

   public StateBase CurrentState
   {
      get
      {
         return _currentState;
      }
   }

   
   #region UnityMethods
      public void RegisterStates(T typeEnum,StateBase stateBase)
      {
         //DictionaryState = new Dictionary<T, StateBase>();
         DictionaryState.Add(typeEnum,stateBase);
      }
      public void Update()
      {
         if (_currentState != null)
         {
            _currentState.OnStateStay();
         }
      }

   #endregion

   #region Switch
   public void SwitchStates(T state)
      {
         if (_currentState != null)
         {
            _currentState.OnStateExit();
         }

         _currentState = DictionaryState[state];

         if (_currentState != null)
         {
            _currentState.OnStateEnter();
         }

      }

   #endregion

   public void Init()
   {
      DictionaryState = new Dictionary<T, StateBase>();
   }
}
