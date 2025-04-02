using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class CameraFieldView : MonoBehaviour
    {
        [SerializeField] private Camera _playerCamera;

        [Space]
        [SerializeField] private float DefaultValue = 60f;
        [SerializeField] private float RunValue = 65f;
        [SerializeField] private float SpeedValueChange = 10f;

        private float currentValue = 0;

        private void Awake()
        {
            Set(DefaultValue);
        }

        public void SetRun(bool isRun)
        {
            Set(isRun ? RunValue : DefaultValue);
        }

        public void Set(float value)
        {
            currentValue = value;
        }

        private void Update()
        {
            _playerCamera.fieldOfView = Mathf.Lerp(_playerCamera.fieldOfView, currentValue, SpeedValueChange * Time.deltaTime);
        }
    }
}
