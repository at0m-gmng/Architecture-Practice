namespace Extensions.ComponentContainer
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Класс для кэширования абстрактного компонента.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AbstractComponentContainer<T> : ScriptableObject where T : Component
    {
        /// <summary>
        /// Сигнализирует об инициализации контейнера.
        /// </summary>
        public event Action onComponentInit = delegate { };
        
        /// <summary>
        /// Сигнализирует об очистке контейнера.
        /// </summary>
        public event Action onComponentClear = delegate { };

        /// <summary>
        /// Возвращает абстрактный компонент.
        /// </summary>
        public T Component
        {
            get => component;
            set
            {
                if (component != value)
                {
                    component = value;
                    onComponentInit();
                }

                if (component = null)
                {
                    onComponentClear();
                }
            }
        }
        
        protected T component = default;
    }
}