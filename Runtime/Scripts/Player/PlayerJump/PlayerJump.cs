using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private PlayerGravity _playerGravity;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _forceJump;
        [SerializeField] private float _gravityVelocity;
        [SerializeField] private bool _isDoubleJump;
        
        public void Jump()
        {
            _characterController.Move(Vector3.up * _forceJump);
            _playerGravity.SetVelocity(_gravityVelocity);
        }
    }
}
