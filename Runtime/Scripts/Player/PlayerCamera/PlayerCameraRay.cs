using naa.FirstPersonController.InteractingObject;
using System;
using System.Linq;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerCameraRay : MonoBehaviour
    {
        public event Action<bool> OnChangeDragAndDrop;
        public event Action<float> OnChangeDistance;

        public DragAndDrop DragAndDrop { get; private set; }
        public float MinDistance { get; private set; } 

        [SerializeField] private Camera _camera;

        private const float MaxDistance = 1.4f;

        private DragAndDrop _dragAndDropOld;
        private float _minDistanceOld;

        private void Update()
        {
            var hits = Physics.RaycastAll(_camera.transform.position, _camera.transform.forward, MaxDistance);
            DragAndDrop = CheckRayHits(hits);
            if (_dragAndDropOld != DragAndDrop)
            {
                _dragAndDropOld = DragAndDrop;
                OnChangeDragAndDrop?.Invoke(DragAndDrop);
            }


            MinDistance = CheckDistace(hits);
            if (_minDistanceOld != MinDistance)
            {
                _minDistanceOld = MinDistance;
                OnChangeDistance?.Invoke(MinDistance);
            }
        }

        private DragAndDrop CheckRayHits(RaycastHit[] hits)
        {
            foreach (var hit in hits)
            {
                if (hit.rigidbody && hit.collider.TryGetComponent<DragAndDrop>(out var drag))
                {
                    return drag;
                }
            }

            return null;
        }

        private float CheckDistace(RaycastHit[] hits)
        {
            return hits.Where(o => !o.collider.TryGetComponent<DragAndDrop>(out var drag))
                    .Select(o => Vector3.Distance(transform.position, o.point))
                    .DefaultIfEmpty(MaxDistance)
                    .Min();
        }
    }
}
