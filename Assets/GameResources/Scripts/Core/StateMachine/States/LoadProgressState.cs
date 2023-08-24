using GameResources.Scripts.Core.Data;
using GameResources.Scripts.Services.Data;
using GameResources.Scripts.Services.PersistentProgress;

namespace GameResources.Scripts.Core.StateMachine.States
{
    public class LoadProgressState : IState
    {
        private const string TEST_SCENE = "TestScene";
        
        private readonly GameStateMachine gameStateMachine;
        private readonly IPersistentProgressService progressService;
        private readonly ISaveLoadService saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            this.gameStateMachine = gameStateMachine;
            this.progressService = progressService;
            this.saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            gameStateMachine.Enter<LoadLevelState, string>(progressService.Progress.WorldData.PositionOnLevel.Level);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew() 
            
            
            => progressService.Progress = saveLoadService.LoadProgress() ?? NewProgress();

        private PlayerProgress NewProgress() => new PlayerProgress(TEST_SCENE);
    }
}