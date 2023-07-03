using UnityEngine;

namespace GameResources.Scripts.Services.Inputs
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