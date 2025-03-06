using naa.FirstPersonController.PlayerInput;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputObserver _inputObserver;
        [SerializeField] private PlayerParameters _playerParameters;

        [Space]
        [SerializeField] private PlayerRotate _playerHead;
        [SerializeField] private PlayerMove _playerMove;

        private void Awake()
        {
            _inputObserver.OnRotate += RotateHandler;
            _inputObserver.OnMove += MoveHandler;
        }

        private void Start()
        {
            _playerMove.Init(_playerParameters);
        }

        public void RotateHandler(Vector2 vector)
        {
            _playerHead.Rotate(vector);
        }

        public void MoveHandler(Vector2 vector)
        {
            var direction = vector.y * _playerHead.transform.forward + vector.x * _playerHead.transform.right;
            _playerMove.Move(direction);
        }

        private void OnDestroy()
        {
            _inputObserver.OnRotate -= RotateHandler;
            _inputObserver.OnMove -= MoveHandler;
        }
    }
}
