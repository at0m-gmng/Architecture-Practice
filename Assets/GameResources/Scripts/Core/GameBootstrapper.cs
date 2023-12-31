using GameResources.Scripts.Core.StateMachine.States;
using GameResources.Scripts.UI;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace GameResources.Scripts.Core
{
    /// <summary>
    /// Единая точка входа 
    /// </summary>
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain loadingCurtain = default;
        
        private Game game;

        private void Awake()
        {
            game = new Game(this, loadingCurtain);
            game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}
