namespace TDS.Animations.Characters
{
    using UnityEngine;

    public class CharacterMovementAnimator : MonoBehaviour
    {
        protected const string FORWARD = "Forward";
        protected const string IS_IDLE = "IsIdle";

        /// <summary>
        /// Возвращает скорость воспроизведения анимации движения вперёд.
        /// Зависит от скорости персонажа.
        /// </summary>
        protected virtual float MovementAnimation
        {
            get => charaterAnimator.GetFloat(FORWARD);
            set => charaterAnimator.SetFloat(FORWARD, value);
        }
        
        /// <summary>
        /// Возвращает флаг нахождения в состоянии покоя.
        /// </summary>
        protected virtual bool IsIdle
        {
            get => charaterAnimator.GetBool(IS_IDLE);
            set
            {
                if (IsIdle != value)
                {
                    charaterAnimator.SetBool(IS_IDLE, value);
                }
                if (value == true)
                {
                    MovementAnimation = 0;   
                }
            }
        }

        [SerializeField]
        protected Animator charaterAnimator = default;

        [SerializeField]
        protected CharacterController characterController =default;
        
        [SerializeField]
        protected float movementMagnitudeBrakeZone = 0.1f;

        [SerializeField] 
        protected float animSpeed = default;
        
        protected float speed = default;
        
        protected virtual void Update() => UpdateMovementStates();
        
        protected virtual void UpdateMovementStates()
        {
            speed = Mathf.Lerp(MovementAnimation, characterController.velocity.magnitude, animSpeed * Time.deltaTime);
            IsIdle = speed < movementMagnitudeBrakeZone;
            if (!IsIdle)
            {
                MovementAnimation = speed;
            }
        }
    }
}
