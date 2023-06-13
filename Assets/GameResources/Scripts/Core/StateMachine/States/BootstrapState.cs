using System;
using GameResources.Scripts.Services;
using UnityEngine;

namespace GameResources.Scripts.Core.StateMachine.States
{
    /// <summary>
    /// Состояние регистрации
    /// </summary>
    public class BootstrapState : IState
    {
        private const string InitialScene = "InitialScene";
        private readonly GameStateMachine stateMachine;
        private readonly SceneLoader sceneLoader;

        public  BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            this.stateMachine = stateMachine;
            this.sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            RegisterServices();
            sceneLoader.Load(InitialScene, onLoad: EnterLoadLevel);
        }

        public void Exit()
        {
            
        }

        private void EnterLoadLevel()
        {
            stateMachine.Enter<LoadLevelState, string>("TestScene");
        }

        private void RegisterServices() => Game.InputService = RegisterInputService();


        private static IInputService RegisterInputService()
        {
            if (Application.isEditor)
            {
                return  new StandaloneInputService();
            }
            else
            {
                return new MobileInputService();
            }
        }
    }
}
