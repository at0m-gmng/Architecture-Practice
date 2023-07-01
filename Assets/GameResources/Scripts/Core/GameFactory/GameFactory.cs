using UnityEngine;

namespace GameResources.Scripts.Core.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private const string PREFAB_HUD = "Prefabs/UI/HUD";
        private const string PREFAB_CHARACTER = "Prefabs/Characters/Character_Explorer_Male_01";
        
        public GameObject CreateHero(GameObject heroObject) 
            => Instantiate(PREFAB_CHARACTER, at: heroObject.transform.position);
        
        public void CreateHUD() => Instantiate(PREFAB_HUD);
        
        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        
        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

    }
}