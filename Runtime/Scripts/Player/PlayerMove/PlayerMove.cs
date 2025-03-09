using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerMove : MonoBehaviour
    {
        public bool IsRun { get; set; }

        [SerializeField] private CharacterController _characterController;

        private const float AddFactorStamina = 0.3f;
        private const float RemoveFactorStamina = 1f;

        private float _stamina;
        private float _runFactor;
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
            _runFactor = 1f;
            if (IsRun && _isMotionNow && !_isStaminaBlocked && RemoveStamina())
            {
                _runFactor = _playerParameters.RunFactor;
            }
            else
            {
                AddStamina();
                _runFactor = 1f;
            }
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
            _characterController.Move(vector.normalized * _playerParameters.MoveSpeed * _runFactor * Time.deltaTime);
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
