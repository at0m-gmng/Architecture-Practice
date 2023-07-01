using GameResources.Scripts.Core;
using GameResources.Scripts.Services;
using UnityEngine;

namespace GameResources.Scripts.Input
{
    /// <summary>
    /// Класс отвечающий за передвижение персонажа
    /// </summary>
    public class CharacterMovement : MonoBehaviour
    {
        private const float Epsilon = 0.001f;

        [SerializeField] 
        private CharacterController characterController = default;

        [SerializeField]
        private float movementSpeed = default;

        private IInputService inputService;
        private Camera camera;

        private void Awake() => inputService = AllServices.Container.Single<IInputService>();

        private void Start() => camera = Camera.main;

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (inputService.Axis.sqrMagnitude > Epsilon)
            {
                movementVector = camera.transform.TransformDirection(inputService.Axis);
                movementVector.y = 0f;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
            characterController.Move(movementSpeed * movementVector * Time.deltaTime );

        }
    }
}
