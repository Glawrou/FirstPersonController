using naa.FirstPersonController.PlayerInput;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputObserver _inputObserver;
        [SerializeField] private PlayerParameters _playerParameters;

        [Space]
        [SerializeField] private PlayerRotate _playerRotate;
        [SerializeField] private PlayerMove _playerMove;
        [SerializeField] private PlayerJump _playerJump;

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
            _playerMove.Init(_playerParameters);
            _playerJump.Init(_playerParameters);
        }

        private void RotateHandler(Vector2 vector)
        {
            _playerRotate.Rotate(vector);
        }

        private void MoveHandler(Vector2 vector)
        {
            var direction = vector.y * _playerRotate.transform.forward + vector.x * _playerRotate.transform.right;
            _playerMove.Move(direction);
        }

        private void RunHandler(bool isRun)
        {
            _playerMove.IsRun = isRun;
        }

        private void SnakingHandler(bool isSnaking)
        {
            _playerMove.IsSneaking = isSnaking;
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
