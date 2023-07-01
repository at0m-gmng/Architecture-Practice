using GameResources.Scripts.Core.AssetManager;
using UnityEngine;

namespace GameResources.Scripts.Core.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            this.assetProvider = assetProvider;
        }
        
        public GameObject CreateHero(GameObject heroObject) 
            => assetProvider.Instantiate(AssetPath.PREFAB_CHARACTER, at: heroObject.transform.position);
        
        public void CreateHUD() => assetProvider.Instantiate(AssetPath.PREFAB_HUD);
    }
}