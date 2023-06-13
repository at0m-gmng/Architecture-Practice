using UnityEngine;

namespace GameResources.Scripts.Services
{    
    /// <summary>
    /// Интерфейс инпут системы
    /// </summary>
    public interface IInputService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();

    }
}