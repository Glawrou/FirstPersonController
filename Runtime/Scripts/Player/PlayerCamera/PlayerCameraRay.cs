using naa.FirstPersonController.InteractingObject;
using System;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerCameraRay : MonoBehaviour
    {
        public event Action<bool> OnChengeIsRayHit;

        [SerializeField] private Camera _camera;

        private const float MaxDistance = 1.4f;

        private bool _isRayHitOld;
        private bool _isRayHitNew;

        private void Update()
        {
            var hits = Physics.RaycastAll(_camera.transform.position, _camera.transform.forward, MaxDistance);
            _isRayHitNew = CheckRayHits(hits);
            if (_isRayHitOld != _isRayHitNew)
            {
                _isRayHitOld = _isRayHitNew;
                OnChengeIsRayHit?.Invoke(_isRayHitNew);
            }
        }

        private bool CheckRayHits(RaycastHit[] hits)
        {
            foreach (var hit in hits)
            {
                if (hit.rigidbody && hit.collider.TryGetComponent<DragAndDrop>(out var drag))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
