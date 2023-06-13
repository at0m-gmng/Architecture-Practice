using GameResources.Scripts.Input;
using GameResources.Scripts.UI;
using UnityEngine;

namespace GameResources.Scripts.Core.StateMachine.States
{
    /// <summary>
    /// Состояние загрузки уровня
    /// </summary>
    public class LoadLevelState: IPayloadedState<string>
    {
        private const string PREFAB_HUD = "Prefabs/UI/HUD";
        private const string PREFAB_CHARACTER = "Prefabs/Characters/Character_Explorer_Male_01";
        private const string INITIAL_POINT = "InitialPoint";
        
        private readonly GameStateMachine stateMachine;
        private readonly SceneLoader sceneLoader;
        private readonly LoadingCurtain loadingCurtain;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            this.stateMachine = stateMachine;
            this.sceneLoader = sceneLoader;
            this.loadingCurtain = loadingCurtain;
        }

        public void Enter(string sceneName)
        {
            loadingCurtain.Show();
            sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            GameObject initPoint = GameObject.FindWithTag(INITIAL_POINT);
            
            GameObject hero = Instantiate(PREFAB_CHARACTER, at: initPoint.transform.position);
            Instantiate(PREFAB_HUD);
            
            CameraFollow(hero);
            
            stateMachine.Enter<GameLoopState>();
        }

        private GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        
        private GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
        
        private void CameraFollow(GameObject hero) => Camera.main.GetComponent<CharacterCameraFollow>().Follow(hero);

        public void Exit()
        {
            loadingCurtain.Hide();
        }
    }
}