using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private PlayerGravity _playerGravity;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerTriggerGround _playerTriggerGround;

        private const float OffsetUp = 0.35f;

        private bool _isThereSecondJump;
        private PlayerParameters _playerParameters;

        public void Init(PlayerParameters parameters)
        {
            _playerParameters = parameters;
        }

        public void Jump()
        {
            if (_playerParameters == null)
            {
                Debug.LogError("naa >> FirstPersonController >> Player >> PlayerJump >> (_playerParameters == NULL)");
                return;
            }

            if (!_playerTriggerGround.IsGrounded && !_playerParameters.IsDoubleJump)
            {
                return;
            }
            else if (!_playerTriggerGround.IsGrounded && _playerParameters.IsDoubleJump && _isThereSecondJump)
            {
                _isThereSecondJump = false;
                Jump(OffsetUp, -_playerParameters.ForceJump);
            }
            else if (_playerTriggerGround.IsGrounded)
            {
                _isThereSecondJump = true;
                Jump(OffsetUp, -_playerParameters.ForceJump);
            }
        }

        private void Jump(float offsetUp, float gravityVelocity)
        {
            _characterController.Move(Vector3.up * offsetUp);
            _playerGravity.SetVelocity(gravityVelocity);
        }
    }
}
