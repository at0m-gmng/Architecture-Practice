namespace GameResources.Scripts.Input
{
    using Core.Data;
    using Services;
    using Services.Inputs;
    using Services.PersistentProgress;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    /// <summary>
    /// Класс отвечающий за передвижение персонажа
    /// </summary>
    public class CharacterMovement : MonoBehaviour, ISaveProgress
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

        public void UpdateProgress(PlayerProgress progress) 
            => progress.WorldData.PositionOnLevel = new PositionOnLevel(GetCurrentLevelName(), 
                                                                        transform.position.AsVectorData());

        public void LoadProgress(PlayerProgress progress)
        {
            if (GetCurrentLevelName() == progress.WorldData.PositionOnLevel.Level)
            {
                Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;
                if (savedPosition != null)
                {
                    Warp(savedPosition);   
                }
            }

        }

        private void Warp(Vector3Data savedPosition)
        {
            characterController.enabled = false;
            transform.position = savedPosition.AsUnityVector();
            characterController.enabled = true;
        }

        private string GetCurrentLevelName() => SceneManager.GetActiveScene().name;
    }
}
