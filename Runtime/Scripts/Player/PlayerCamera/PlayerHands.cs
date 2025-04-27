using naa.FirstPersonController.InteractingObject;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerHands : MonoBehaviour
    {
        [SerializeField] private PlayerCameraRay _cameraRay;

        private DragAndDrop _item;

        private float MaxDistance = 0.9f;

        private const float Speed = 30f;
        private const float SpeedRotation = 30f;

        private void Awake()
        {
            _cameraRay.OnChangeDistance += ChangeDistanceHandler;
        }

        public void SetItem(DragAndDrop item)
        {
            if (_item)
            {
                _item.Rigidbody.useGravity = true;
            }

            _item = item;
            if (!_item)
            {
                return;
            }

            _item.Rigidbody.useGravity = false;
        }

        private void Update()
        {
            if (!_item)
            {
                return;
            }

            var lerp = Vector3.Lerp(_item.transform.position, transform.position, Speed * Time.deltaTime);
            _item.Rigidbody.MovePosition(lerp);
        }

        private void ChangeDistanceHandler(float distance)
        {
            distance = Mathf.Min(distance, MaxDistance);
            var newPos = _cameraRay.transform.position + (_cameraRay.transform.forward * distance);
            transform.position = newPos;
        }

        private void OnDestroy()
        {
            _cameraRay.OnChangeDistance -= ChangeDistanceHandler;
        }
    }
}
