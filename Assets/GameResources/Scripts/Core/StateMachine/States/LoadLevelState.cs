using GameResources.Scripts.Input;
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

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory)
        {
            this.stateMachine = stateMachine;
            this.sceneLoader = sceneLoader;
            this.loadingCurtain = loadingCurtain;
            this.gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            loadingCurtain.Show();
            sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            GameObject hero = gameFactory.CreateHero(GameObject.FindWithTag(INITIAL_POINT));
            gameFactory.CreateHUD();
            
            CameraFollow(hero);
            
            stateMachine.Enter<GameLoopState>();
        }

        private void CameraFollow(GameObject hero) => Camera.main.GetComponent<CharacterCameraFollow>().Follow(hero);

        public void Exit()
        {
            loadingCurtain.Hide();
        }
    }
}