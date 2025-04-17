using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string IsMoveKey = "IsMove";
        private const string IsRunKey = "IsRun";
        private const string IsSneakingKey = "IsSneaking";
        private const string MoveYKey = "MoveY";
        private const string MoveXKey = "MoveX";

        public void SetSneaking(bool isSneaking)
        {
            _animator.SetBool(IsSneakingKey, isSneaking);
        }

        public void SetRun(bool isRun)
        {
            _animator.SetBool(IsRunKey, isRun);
        }

        public void SetMove(Vector2 vector)
        {
            _animator.SetBool(IsMoveKey, vector.magnitude != 0);
            _animator.SetFloat(MoveYKey, vector.y);
            _animator.SetFloat(MoveXKey, vector.x);
        }
    }
}
