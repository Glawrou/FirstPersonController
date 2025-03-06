using System;
using UnityEngine;

namespace naa.FirstPersonController.PlayerInput
{
    public abstract class InputObserver : MonoBehaviour
    {
        public event Action<Vector2> OnRotate;
        public event Action<Vector2> OnMove;
        public event Action OnJump;

        [field: SerializeField] public float SensitivityRotateHead { get; set; }
        [field: SerializeField] public bool InversionAxisY { get; set; }

        protected void RotateInvoke(Vector2 vector)
        {
            var y = InversionAxisY ? vector.y : -vector.y;
            OnRotate?.Invoke(new Vector2(vector.x, y));
        }

        protected void MoveInvoke(Vector2 vector)
        {
            OnMove?.Invoke(vector);
        }

        protected void JumpInvoke()
        {
            OnJump?.Invoke();
        }
    }
}
