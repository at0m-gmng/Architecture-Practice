using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  GameResources.Scripts.UI
{
    /// <summary>
    /// Класс для показа экрана загрузки.
    /// </summary>
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup loadingCurtain = default;
        
        [SerializeField]
        private float loadingCurtainAlphaSpeed = 0.03f;

        private void Awake() => DontDestroyOnLoad(this);

        /// <summary>
        /// Отвечает за показ экрана загрузки.
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
            loadingCurtain.alpha = 1f;
        }
        
        /// <summary>
        /// Отвечает за затемнение экрана загрузки.
        /// </summary>
        public void Hide() => StartCoroutine(Fade());

        private IEnumerator Fade()
        {
            while (loadingCurtain.alpha > 0)
            {
                loadingCurtain.alpha -= loadingCurtainAlphaSpeed;
                yield return new WaitForSeconds(loadingCurtainAlphaSpeed);
            }

            gameObject.SetActive(false);
        }
    }
}

