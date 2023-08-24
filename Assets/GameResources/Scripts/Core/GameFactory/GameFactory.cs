using System.Collections.Generic;
using GameResources.Scripts.Core.AssetManager;
using UnityEngine;
using GameResources.Scripts.Services.PersistentProgress;

namespace GameResources.Scripts.Core.GameFactory
{
    public class GameFactory : IGameFactory
    {
        /// <summary>
        /// Набор интерфейсов для чтения.
        /// </summary>
        public List<ISaveProgressReader> ProgressReaders { get; } = new List<ISaveProgressReader>();

        /// <summary>
        /// Набор интерфейсов для записи.
        /// </summary>
        public List<ISaveProgress> ProgressWriters { get; } = new List<ISaveProgress>();
        
        private readonly IAssetProvider assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            this.assetProvider = assetProvider;
        }
        
        public GameObject CreateHero(GameObject heroObject) 
            => InstantiateAndRegistered(AssetPath.PREFAB_CHARACTER, heroObject.transform.position);

        public void CreateHUD() => InstantiateAndRegistered();

        public void CleanUp()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateAndRegistered(string assetPath, Vector3 targetPosition)
        {
            GameObject targetObject = assetProvider.Instantiate(assetPath, at: targetPosition);
            RegisterProgressWatcher(targetObject);
            return targetObject;
        }

        private GameObject InstantiateAndRegistered()
        {
            GameObject targetObject = assetProvider.Instantiate(AssetPath.PREFAB_HUD);
            return targetObject;
        }

        private void RegisterProgressWatcher(GameObject initializedObject)
        {
            foreach (ISaveProgressReader progressReader in initializedObject.GetComponentsInChildren<ISaveProgressReader>())
            {
                Register(progressReader);
            }
        }

        private void Register(ISaveProgressReader progressReader)
        {
            ProgressReaders.Add(progressReader);
            
            if (progressReader is ISaveProgress progressWriter)
            {
                ProgressWriters.Add(progressWriter);
            }
        }
    }
}