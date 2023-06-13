using System.Collections;
using UnityEngine;

namespace GameResources.Scripts.Core
{
    /// <summary>
    /// Интерфейс для вызова IEnumerator
    /// </summary>
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}