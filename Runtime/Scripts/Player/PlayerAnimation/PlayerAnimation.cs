using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string MoveKey = "IsMove";
        private const string MoveYKey = "MoveY";
        private const string MoveXKey = "MoveX";

        public void SetMove(Vector2 vector)
        {
            _animator.SetBool(MoveKey, vector.magnitude != 0);
            _animator.SetFloat(MoveYKey, vector.y);
            _animator.SetFloat(MoveXKey, vector.x);
        }
    }
}
