using naa.FirstPersonController.PlayerInput;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputObserver _inputObserver;
        [SerializeField] private PlayerParameters _playerParameters;

        [Space]
        [SerializeField] private PlayerCameraView _playerCameraView;
        [SerializeField] private PlayerHeadRotate _playerHeadRotate;
        [SerializeField] private PlayerBodyMove _playerBodyMove;
        [SerializeField] private PlayerJump _playerJump;
        [SerializeField] private PlayerAnimation _playerAnimation;

        private void Awake()
        {
            _inputObserver.OnRotate += RotateHandler;
            _inputObserver.OnMove += MoveHandler;
            _inputObserver.OnJump += JumpHandler;
            _inputObserver.OnRun += RunHandler;
            _inputObserver.OnSneaking += SnakingHandler;
        }

        private void Start()
        {
            _playerBodyMove.Init(_playerParameters);
            _playerJump.Init(_playerParameters);
        }

        private void Update()
        {
            _playerCameraView.SetStaminaView(_playerBodyMove.GetStamina());
        }

        private void RotateHandler(Vector2 vector)
        {
            _playerHeadRotate.Rotate(vector);
            _playerBodyMove.Rotate(vector.x);
        }

        private void MoveHandler(Vector2 vector)
        {
            var direction = vector.y * _playerHeadRotate.transform.forward + vector.x * _playerHeadRotate.transform.right;
            _playerBodyMove.Move(direction);
            _playerAnimation.SetMove(vector);
        }

        private void RunHandler(bool isRun)
        {
            _playerCameraView.SetRun(isRun);
            _playerBodyMove.IsRun = isRun;
        }

        private void SnakingHandler(bool isSnaking)
        {
            _playerBodyMove.IsSneaking = isSnaking;
        }

        private void JumpHandler()
        {
            _playerJump.Jump();
        }

        private void OnDestroy()
        {
            _inputObserver.OnRotate -= RotateHandler;
            _inputObserver.OnMove -= MoveHandler;
            _inputObserver.OnJump -= JumpHandler;
            _inputObserver.OnRun -= RunHandler;
            _inputObserver.OnSneaking -= SnakingHandler;
        }
    }
}
