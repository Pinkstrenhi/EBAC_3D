using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using Ebac.StateMachine;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        Intro,
        Gameplay,
        Pause, 
        Win, 
        Lose
    }

    public StateMachine<GameStates> stateMachine;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        stateMachine = new StateMachine<GameStates>();
        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.Intro,new GMStates_Intro());
        stateMachine.RegisterStates(GameStates.Gameplay,new StateBase());
        stateMachine.RegisterStates(GameStates.Pause,new StateBase());
        stateMachine.RegisterStates(GameStates.Win,new StateBase());
        stateMachine.RegisterStates(GameStates.Lose,new StateBase());
        
        stateMachine.SwitchStates(GameStates.Intro);
    }
}
