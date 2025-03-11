using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerGravity : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerTriggerGround _playerTriggerGround;
        [SerializeField] private float _gravityFactor = 16f;
        [SerializeField] private float _gravityMax = 20f;

        private const float DefaultVelocity = 2f;

        private float _verticalVelocity;

        private void Update()
        {
            if (_playerTriggerGround.IsGrounded)
            {
                _verticalVelocity = DefaultVelocity;
            }

            SetVelocity(_verticalVelocity + _gravityFactor * Time.deltaTime);
            _characterController.Move(-Vector3.up * _verticalVelocity * Time.deltaTime);
        }

        public void SetVelocity(float value)
        {
            _verticalVelocity = Mathf.Clamp(value, float.MinValue, _gravityMax);
        }
    }
}
