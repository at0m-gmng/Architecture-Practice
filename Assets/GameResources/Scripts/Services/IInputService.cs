using UnityEngine;

namespace GameResources.Scripts.Services
{    
    /// <summary>
    /// Интерфейс инпут системы
    /// </summary>
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();

    }
}