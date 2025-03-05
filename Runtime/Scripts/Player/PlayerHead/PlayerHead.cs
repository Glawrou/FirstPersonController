using naa.FirstPersonController.Input;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerHead : MonoBehaviour
    {
        [SerializeField] private InputObserver _inputObserver;
        [SerializeField] private RangeRotateHead _rangeRotate;

        private void Awake()
        {
            _inputObserver.OnRotateHead += RotateHeadHandler;
        }

        public void Rotate(Vector2 vector)
        {
            var newRotateEuler = transform.rotation.eulerAngles + new Vector3(vector.y, vector.x, 0f);
            transform.rotation = Quaternion.Euler(_rangeRotate.ClampEuler(newRotateEuler));
        }

        private void RotateHeadHandler(Vector2 vector)
        {
            Rotate(vector);
        }

        private void OnDestroy()
        {
            _inputObserver.OnRotateHead -= RotateHeadHandler;
        }
    }
}
