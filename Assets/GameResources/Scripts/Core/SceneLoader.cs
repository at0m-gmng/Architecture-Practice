using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameResources.Scripts.Core
{
    /// <summary>
    /// Класс для загрузки уровней
    /// </summary>
    public class SceneLoader
    {
        private readonly ICoroutineRunner coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            this.coroutineRunner = coroutineRunner;
        }

        public void Load(string name, Action onLoad = null)
        {
            coroutineRunner.StartCoroutine(LoadScene(name, onLoad));
        }

        public IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded.Invoke();
                yield break;
            }
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (!waitNextScene.isDone)
            {
                yield return null;
            }
            onLoaded?.Invoke();
        }
    }
}