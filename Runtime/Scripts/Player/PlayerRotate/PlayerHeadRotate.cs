using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerHeadRotate : MonoBehaviour
    {
        [SerializeField] private RangeRotateHead _rangeRotate;
        [SerializeField] private Transform _headTransform;

        private void Update()
        {
            transform.position = _headTransform.position;
        }

        public void Rotate(Vector2 vector)
        {
            var newRotateEuler = transform.rotation.eulerAngles + new Vector3(vector.y, 0f, 0f) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(_rangeRotate.ClampEuler(newRotateEuler));
        }
    }
}
