using UnityEngine;

namespace GameResources.Scripts.Services
{
    /// <summary>
    /// Класс реализующий Input на mobile платформах
    /// </summary>
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}