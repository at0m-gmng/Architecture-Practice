using GameResources.Scripts.Core.AssetManager;
using GameResources.Scripts.Services;
using UnityEngine;

namespace GameResources.Scripts.Core.StateMachine.States
{
    using GameFactory;
    /// <summary>
    /// Состояние регистрации
    /// </summary>
    public class BootstrapState : IState
    {
        private const string InitialScene = "InitialScene";
        private const string TEST_SCENE = "TestScene";
        
        private readonly GameStateMachine stateMachine;
        private readonly SceneLoader sceneLoader;
        private readonly AllServices services;

        public  BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices allSercives)
        {
            this.stateMachine = stateMachine;
            this.sceneLoader = sceneLoader;
            services = allSercives;
            
            RegisterServices();
        }
        
        public void Enter() => sceneLoader.Load(InitialScene, onLoad: EnterLoadLevel);

        public void Exit()
        {
            
        }

        private void EnterLoadLevel() => stateMachine.Enter<LoadLevelState, string>(TEST_SCENE);


        private void RegisterServices()
        {
            services.RegisterSingle<IInputService>(InputService());
            services.RegisterSingle<IAssetProvider>(new AssetProvider());
            services.RegisterSingle<IGameFactory>(new GameFactory(services.Single<IAssetProvider>()));
        }

        private static IInputService InputService()
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
