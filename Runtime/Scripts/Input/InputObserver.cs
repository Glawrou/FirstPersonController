using System;
using UnityEngine;

namespace naa.FirstPersonController.Input
{
    public abstract class InputObserver : MonoBehaviour
    {
        public event Action<Vector2> OnRotateHead;

        [field: SerializeField] public float SensitivityRotateHead { get; set; }
        [field: SerializeField] public bool InversionAxisY { get; set; }

        protected void RotateHeadInvoke(Vector2 vector)
        {
            var y = InversionAxisY ? vector.y : -vector.y;
            OnRotateHead?.Invoke(new Vector2(vector.x, y));
        }
    }
}
