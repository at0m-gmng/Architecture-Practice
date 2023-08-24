using System.Collections.Generic;
using GameResources.Scripts.Services;
using GameResources.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace GameResources.Scripts.Core.GameFactory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject heroObject);
        void CreateHUD();

        /// <summary>
        /// Набор интерфейсов для чтения.
        /// </summary>
        List<ISaveProgressReader> ProgressReaders { get; }

        /// <summary>
        /// Набор интерфейсов для записи.
        /// </summary>
        List<ISaveProgress> ProgressWriters { get; }

        void CleanUp();
    }
}