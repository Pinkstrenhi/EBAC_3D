using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


public class StateMachine : MonoBehaviour
{
   public static StateMachine Instance;
   #region Enum
      public enum States
      {
         None
      }
      
   #endregion
   public Dictionary<States, StateBase> DictionaryState;
   private StateBase _currentState;
   public float timeToStartGame = 1f;

   #region UnityMethods
      private void Awake()
      {
         Instance = this;
         DictionaryState = new Dictionary<States, StateBase>();
         DictionaryState.Add(States.None, new StateBase());
         Invoke(nameof(StartGame),timeToStartGame);
      }
      private void Update()
      {
         if (_currentState != null)
         {
            _currentState.OnStateStay();
         }
      }

   #endregion

   #region Switch
   
      [Button]
      private void StartGame()
      {
         SwitchStates(States.None);
      }
      #if UNITY_EDITOR
         [Button]
         private void SwitchStatesToNone()
         {
            SwitchStates(States.None);
         }
      #endif
      public void SwitchStates(States state)
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

   #region Reset

      public void ResetPosition()
      {
         SwitchStates(States.None);
      }

   #endregion
   
}
