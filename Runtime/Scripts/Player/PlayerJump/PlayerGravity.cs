using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerGravity : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerTriggerGround _playerTriggerGround;
        [SerializeField] private float _gravityFactor = 16f;
        [SerializeField] private float _gravityMax = 20f;

        private const float DefaultVelocity = 0.2f;

        private float _verticalVelocity;

        private void Update()
        {
            _playerTriggerGround.CalculateGround();
            var newGravity = _playerTriggerGround.IsGrounded 
                ? DefaultVelocity : 
                _verticalVelocity + _gravityFactor * Time.deltaTime;

            SetVelocity(newGravity);
            _characterController.Move(-Vector3.up * _verticalVelocity * Time.deltaTime);
        }

        public void SetVelocity(float value)
        {
            _verticalVelocity = Mathf.Clamp(value, float.MinValue, _gravityMax);
        }

#if UNITY_EDITOR
        private void OnGUI()
        {
            GUI.TextArea(new Rect(Vector2.zero, new Vector2(150, 20)), $"GravityValue: {Mathf.RoundToInt(_verticalVelocity)}");
        }
#endif
    }
}
