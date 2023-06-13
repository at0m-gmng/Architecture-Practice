using UnityEngine;

namespace GameResources.Scripts.Input
{
    /// <summary>
    /// Класс позволяющий камере следовать за персонажем
    /// </summary>
    public class CharacterCameraFollow : MonoBehaviour
    {
        [SerializeField]
        private float rotationAngleX = default;

        [SerializeField]
        private float distance = default;

        [SerializeField]
        private float offsetY = default;

        private Transform following = default;

        private void LateUpdate()
        {
            if (following == null)
            {
                return;
            }

            Quaternion rotation = Quaternion.Euler(rotationAngleX, 0f, 0f);
            Vector3 position = rotation * new Vector3(0f, 0f, -distance) + FollowingPointPosition();

            transform.position = position;
            transform.rotation = rotation;
        }

        public void Follow(GameObject followingObject) => following = followingObject.transform;

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = following.position;
            followingPosition.y += offsetY;
            return followingPosition;
        }
    }
}