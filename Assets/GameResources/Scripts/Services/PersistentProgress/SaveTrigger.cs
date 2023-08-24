using GameResources.Scripts.Core.Data;

namespace GameResources.Scripts.Services.PersistentProgress
{
    using UnityEngine;
    using Data;

    public class SaveTrigger : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider saveCollider = default;

        private ISaveLoadService _saveLoadService;

        private void Awake() => _saveLoadService = AllServices.Container.Single<ISaveLoadService>();

        private void OnTriggerEnter(Collider other)
        {
            if (_saveLoadService != null)
            {
                _saveLoadService.SaveProgress();
                gameObject.SetActive(false);
            }
        }

        private void OnDrawGizmos()
        {
            if (saveCollider != null)
            {
                Gizmos.color = new Color32(30, 200, 30, 130);
                Gizmos.DrawCube(transform.position + saveCollider.center, saveCollider.size);
            }
        }
    }
}
