using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerGravity : MonoBehaviour
    {
        [SerializeField] private PlayerTriggerGround _groundTrigger;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _gravityFactor = 6.4f;
        [SerializeField] private float _gravityMax = 9.8f;

        private float _verticalVelocity;

        private void Update()
        {
            if (_groundTrigger.IsGround)
            {
                _verticalVelocity = 0;
                return;
            }

            _verticalVelocity = Mathf.Clamp(_verticalVelocity + _gravityFactor, 0, _gravityMax);
            _characterController.Move(-Vector3.up * _verticalVelocity * Time.deltaTime);
        }
    }
}
