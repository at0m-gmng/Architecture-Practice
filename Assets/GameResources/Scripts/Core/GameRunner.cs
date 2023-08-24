using System;
using UnityEngine;

namespace GameResources.Scripts.Core
{   
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] 
        private GameBootstrapper gameBootstrapperPrefab = null;
        
        private void Awake()
        {
            GameBootstrapper gameBootstrapper = FindObjectOfType<GameBootstrapper>();

            if (gameBootstrapper == null)
            {
                Instantiate(gameBootstrapperPrefab);
            }
        }
    }
}