using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerTriggerUp : MonoBehaviour
    {
        public bool IsUp { get; private set; }

        [SerializeField] private LayerMask _layerMaskTrigger;
        [SerializeField] private float _radiusTrigger = 0.25f;

        private void Update()
        {
            CalculateGround();
        }

        public void CalculateGround()
        {
            var colliders = Physics.OverlapSphere(transform.position, _radiusTrigger, _layerMaskTrigger);
            IsUp = GetGround(colliders);
        }

        private bool GetGround(Collider[] colliders)
        {
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent<PlayerController>(out var player))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
