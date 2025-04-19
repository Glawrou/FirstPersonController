using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerBodyMove : MonoBehaviour
    {
        public bool IsRun { get; set; }
        public bool IsSneaking { get; set; }

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private PlayerCharaterSetting _playerCharaterSetting;
        [SerializeField] private PlayerTriggerUp _triggerUp;

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
            var moveType = GetMoveType();
            UpdateMoveFactor(moveType);
            UpdateMoveAnimation(moveType);
            UpdatePlayerCharacterSettings(moveType);
        }

        public void Rotate(float yAxis)
        {
            var currentRotation = _characterController.transform.rotation.eulerAngles;
            var newRotateEuler = currentRotation + new Vector3(0, yAxis, 0f) * Time.deltaTime;
            _characterController.transform.rotation = Quaternion.Euler(newRotateEuler);
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

        private void UpdateMoveFactor(MoveType moveType)
        {
            switch (moveType)
            {
                case MoveType.Sneaking:
                    AddStamina();
                    _moveFactor = _playerParameters.SneakingFactor;
                    break;
                case MoveType.Runing:
                    _moveFactor = _playerParameters.RunFactor;
                    break;
                default:
                    AddStamina();
                    _moveFactor = 1f;
                    break;
            }
        }

        private void UpdateMoveAnimation(MoveType moveType)
        {
            _playerAnimation.SetMoveType(moveType);
        }

        private void UpdatePlayerCharacterSettings(MoveType moveType)
        {
            _playerCharaterSetting.Set(moveType);
        }

        private MoveType GetMoveType()
        {
            if (IsSneaking || _triggerUp.IsUp)
            {
                return MoveType.Sneaking;
            }
            else if (IsRun && _isMotionNow && !_isStaminaBlocked && RemoveStamina())
            {
                return MoveType.Runing;
            }

            return MoveType.Walking;
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
