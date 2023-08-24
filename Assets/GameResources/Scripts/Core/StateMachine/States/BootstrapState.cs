using GameResources.Scripts.Core.AssetManager;
using GameResources.Scripts.Services;
using GameResources.Scripts.Services.Data;
using GameResources.Scripts.Services.Inputs;
using GameResources.Scripts.Services.PersistentProgress;
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

        private void EnterLoadLevel() => stateMachine.Enter<LoadProgressState>();


        private void RegisterServices()
        {
            services.RegisterSingle<IInputService>(InputService());
            services.RegisterSingle<IAssetProvider>(new AssetProvider());
            services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            services.RegisterSingle<IGameFactory>(new GameFactory(services.Single<IAssetProvider>()));
            services.RegisterSingle<ISaveLoadService>(new SaveLoadService(services.Single<IPersistentProgressService>(), services.Single<IGameFactory>()));
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
