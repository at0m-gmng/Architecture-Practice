using GameResources.Scripts.Core.StateMachine;
using GameResources.Scripts.Services;
using GameResources.Scripts.UI;
using UnityEngine;

namespace GameResources.Scripts.Core
{
    /// <summary>
    /// Контейнер для игры 
    /// </summary>
    public class Game
    {
        public static IInputService InputService;
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain);
        }
    }
}