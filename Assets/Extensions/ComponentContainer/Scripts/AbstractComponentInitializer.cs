namespace Extensions.ComponentContainer
{
    using UnityEngine;

    /// <summary>
    /// Абстрактный класс для инициализации контейнера.
    /// </summary>
    public class AbstractComponentInitializer<T>: MonoBehaviour, IComponentInitializer<T> where T : Component  
    {
        [SerializeField]
        protected AbstractComponentContainer<T> componentContainer = default;

        void IComponentInitializer<T>.Init(T component) 
            => componentContainer.Component = component;
    }
}
