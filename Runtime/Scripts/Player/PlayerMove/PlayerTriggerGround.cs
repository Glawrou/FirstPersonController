using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerTriggerGround : MonoBehaviour
    {
        public bool IsGround { get; private set; }
        public Ground CurrentGround { get; private set; }

        [SerializeField] private LayerMask _layerMaskTrigger;
        [SerializeField] private float _radiusTrigger = 0.1f;

        private void Update()
        {
            var colliders = Physics.OverlapSphere(transform.position, _radiusTrigger, _layerMaskTrigger);
            IsGround = GetGround(colliders);
        }

        private bool GetGround(Collider[] colliders)
        {
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent<Ground>(out var ground))
                {
                    CurrentGround = ground;
                    return true;
                }
            }

            CurrentGround = null;
            return false;
        }
    }
}
