using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;

        private PlayerParameters _playerParameters;

        public void Init(PlayerParameters parameters)
        {
            _playerParameters = parameters;
        }

        public void Move(Vector3 vector)
        {
            if (_playerParameters == null)
            {
                Debug.LogError("naa >> FirstPersonController >> Player >> (_playerParameters == NULL)");
            }

            vector.y = 0;
            _characterController.Move(vector.normalized * _playerParameters.MoveSpeed * Time.deltaTime);
        }
    }
}
