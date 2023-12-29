namespace Extensions.ComponentContainer
{
    using UnityEngine;

    /// <summary>
    /// Интерфейс для инициализации абстрактного контейнера.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IComponentInitializer<T> where T: Component
    {
         /// <summary>
         /// Метод для инициализации абстрактного компонента. 
         /// </summary>
         /// <param name="component"></param>
         protected void Init(T component);
    }
}