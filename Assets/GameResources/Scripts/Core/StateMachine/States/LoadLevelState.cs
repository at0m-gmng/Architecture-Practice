using GameResources.Scripts.Input;
using GameResources.Scripts.Services.Data;
using GameResources.Scripts.Services.PersistentProgress;
using GameResources.Scripts.UI;
using UnityEngine;

namespace GameResources.Scripts.Core.StateMachine.States
{
    using GameFactory;
    
    /// <summary>
    /// Состояние загрузки уровня
    /// </summary>
    public class LoadLevelState: IPayloadedState<string>
    {
        private const string INITIAL_POINT = "InitialPoint";
        
        private readonly GameStateMachine stateMachine;
        private readonly SceneLoader sceneLoader;
        private readonly LoadingCurtain loadingCurtain;
        private readonly IGameFactory gameFactory;
        private readonly IPersistentProgressService persistentProgressService;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, 
                              IGameFactory gameFactory, IPersistentProgressService persistentProgressService)
        {
            this.stateMachine = stateMachine;
            this.sceneLoader = sceneLoader;
            this.loadingCurtain = loadingCurtain;
            this.gameFactory = gameFactory;
            this.persistentProgressService = persistentProgressService;
        }

        public void Enter(string sceneName)
        {
            loadingCurtain.Show();
            gameFactory.CleanUp();
            sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            InitializeGameWorld();
            InformProgressReaders();

            stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            foreach (ISaveProgressReader progressReader in gameFactory.ProgressReaders)
            {
                progressReader.LoadProgress(persistentProgressService.Progress);
            }
        }

        private void InitializeGameWorld()
        {
            GameObject hero = gameFactory.CreateHero(GameObject.FindWithTag(INITIAL_POINT));
            gameFactory.CreateHUD();

            CameraFollow(hero);
        }

        private void CameraFollow(GameObject hero) => Camera.main.GetComponent<CharacterCameraFollow>().Follow(hero);

        public void Exit()
        {
            loadingCurtain.Hide();
        }
    }
}