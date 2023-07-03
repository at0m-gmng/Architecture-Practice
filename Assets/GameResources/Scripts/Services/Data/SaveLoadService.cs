using GameResources.Scripts.Core.Data;
using UnityEngine;

namespace GameResources.Scripts.Services.Data
{
    public class SaveLoadService : ISaveLoadService
    {
        protected const string PLAYER_PROGRESS_KEY = "PlayerProgress";

        public void SaveProgress()
        {
            
        }

        public PlayerProgress LoadProgress() 
            => PlayerPrefs.GetString(PLAYER_PROGRESS_KEY)?.ToDeserialized<PlayerProgress>();
    }
}