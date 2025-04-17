using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string TriggerJump = "Jump";
        private const string IsInAirKey = "IsInAir";
        private const string MoveTypeKey = "MoveType";
        private const string MoveYKey = "MoveY";
        private const string MoveXKey = "MoveX";

        private bool _isInAir = false;

        public void SetMoveType(MoveType moveType)
        {
            _animator.SetInteger(MoveTypeKey, (int)moveType);
        }

        public void SetInAir(bool isInAir)
        {
            if (_isInAir == isInAir)
            {
                return; 
            }

            _isInAir = isInAir;
            _animator.SetBool(IsInAirKey, isInAir);
            if (_isInAir)
            {
                _animator.SetTrigger(TriggerJump);
            }
        }

        public void SetMove(Vector2 vector)
        {
            _animator.SetFloat(MoveYKey, vector.y);
            _animator.SetFloat(MoveXKey, vector.x);
        }
    }
}
