using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerMove : MonoBehaviour
    {
        public bool IsRun { get; set; }
        public bool IsSneaking { get; set; } 

        [SerializeField] private CharacterController _characterController;

        private const float AddFactorStamina = 0.3f;
        private const float RemoveFactorStamina = 1f;

        private float _stamina;
        private float _moveFactor;
        private bool _isMotionNow;
        private bool _isStaminaBlocked = false;
        private PlayerParameters _playerParameters;

        public void Init(PlayerParameters parameters)
        {
            _playerParameters = parameters;
            _stamina = _playerParameters.Stamina;
        }

        private void Update()
        {
            UpdateMoveFactor();
        }

        public void Move(Vector3 vector)
        {
            if (_playerParameters == null)
            {
                Debug.LogError("naa >> FirstPersonController >> Player >> PlayerMove >> (_playerParameters == NULL)");
                return;
            }

            _isMotionNow = vector != Vector3.zero;
            vector.y = 0;
            _characterController.Move(vector.normalized * _playerParameters.MoveSpeed * _moveFactor * Time.deltaTime);
        }

        public float GetStamina()
        {
            if (_playerParameters == null)
            {
                Debug.LogError("naa >> FirstPersonController >> Player >> PlayerMove >> (_playerParameters == NULL)");
                return 0f;
            }

            return _stamina / _playerParameters.Stamina;
        }

        private void UpdateMoveFactor()
        {
            _moveFactor = 1f;
            if (IsSneaking)
            {
                AddStamina();
                _moveFactor = _playerParameters.SneakingFactor;
            }
            else if (IsRun && _isMotionNow && !_isStaminaBlocked && RemoveStamina())
            {
                _moveFactor = _playerParameters.RunFactor;
            }
            else
            {
                AddStamina();
                _moveFactor = 1f;
            }
        }

        private void AddStamina()
        {
            _stamina = Mathf.Clamp(_stamina + AddFactorStamina * Time.deltaTime, 0, _playerParameters.Stamina);
            if (_stamina >= _playerParameters.Stamina)
            {
                _isStaminaBlocked = false;
            }
        }

        private bool RemoveStamina()
        {
            var remove = RemoveFactorStamina * Time.deltaTime;
            if (_stamina - remove < 0)
            {
                _isStaminaBlocked = true;
                return false;
            }

            _stamina = _stamina - remove;
            return true;
        }
    }
}
