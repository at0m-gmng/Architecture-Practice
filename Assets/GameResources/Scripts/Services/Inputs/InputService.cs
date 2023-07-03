using UnityEngine;

namespace GameResources.Scripts.Services.Inputs
{
    /// <summary>
    /// Класс реализующий Input
    /// </summary>
    public abstract class InputService : IInputService
    {
        protected const string Vertical = "Vertical";
        protected const string Horizontal = "Horizontal";
        private const string AttackButton = "Fire";

        public abstract Vector2 Axis { get; }

        public bool IsAttackButtonUp() => SimpleInput.GetButton(AttackButton);
    }
}