using System;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    [Serializable]
    public class RangeRotateHead
    {
        [field: SerializeField] public float MinVerticalLimit { get; set; }
        [field: SerializeField] public float MaxVerticalLimit { get; set; }

        private const float CircleAngle = 360f;

        public Vector3 ClampEuler(Vector3 vector)
        {
            if (vector.x > CircleAngle / 2)
            {
                vector.x -= CircleAngle;
            }

            return new Vector3(
                ClampY(vector.x),
                vector.y,
                vector.z);
        }

        public float ClampY(float value)
        {
            if (MinVerticalLimit > MaxVerticalLimit)
            {
                Debug.LogError("naa >> FirstPersonController >> Player >> RangeRotateHead >> (MinVerticalLimit > MaxVerticalLimit)");
            }

            return Mathf.Clamp(value, MinVerticalLimit, MaxVerticalLimit);
        }
    }
}
