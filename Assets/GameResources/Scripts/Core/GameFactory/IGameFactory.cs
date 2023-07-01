using GameResources.Scripts.Services;
using UnityEngine;

namespace GameResources.Scripts.Core.GameFactory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject heroObject);
        void CreateHUD();
    }
}