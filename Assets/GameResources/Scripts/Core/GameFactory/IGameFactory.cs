using UnityEngine;

namespace GameResources.Scripts.Core.GameFactory
{
    public interface IGameFactory
    {
        GameObject CreateHero(GameObject heroObject);
        void CreateHUD();
    }
}