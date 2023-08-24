using GameResources.Scripts.Core.Data;
using GameResources.Scripts.Core.GameFactory;
using GameResources.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace GameResources.Scripts.Services.Data
{
    public class SaveLoadService : ISaveLoadService
    {
        protected const string PLAYER_PROGRESS_KEY = "PlayerProgress";

        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _persistentProgressService;

        public SaveLoadService(IPersistentProgressService persistentProgressService, IGameFactory gameFactory)
        {
            _persistentProgressService = persistentProgressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach (ISaveProgress progressWriter in _gameFactory.ProgressWriters)
            {
                progressWriter.UpdateProgress(_persistentProgressService.Progress);
            }
            
            PlayerPrefs.SetString(PLAYER_PROGRESS_KEY, _persistentProgressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress() 
            => PlayerPrefs.GetString(PLAYER_PROGRESS_KEY)?.ToDeserialized<PlayerProgress>();
    }
}