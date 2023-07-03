﻿using UnityEngine;

namespace GameResources.Scripts.Services.Inputs
{
    /// <summary>
    /// Класс реализующий Input на standalone платформах
    /// </summary>
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
                if (axis == Vector2.zero)
                {
                    axis = new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
                }

                return axis;
            }
        }
    }
}