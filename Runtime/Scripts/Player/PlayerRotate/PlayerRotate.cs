using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private RangeRotateHead _rangeRotate;

        public void Rotate(Vector2 vector)
        {
            var newRotateEuler = transform.rotation.eulerAngles + new Vector3(vector.y, vector.x, 0f) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(_rangeRotate.ClampEuler(newRotateEuler));
        }
    }
}
