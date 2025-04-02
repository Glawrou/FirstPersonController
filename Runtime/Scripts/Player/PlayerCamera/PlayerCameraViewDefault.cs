using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerCameraViewDefault : PlayerCameraView
    {
        [SerializeField] private CameraFieldView _cameraField;
        [SerializeField] private CentralSight _centralSight;
        [SerializeField] private AlphaModifier _stamina;
        [SerializeField] private AlphaModifier _health;

        public override void SetRun(bool isRun) => _cameraField.SetRun(isRun);
        public override void SetStaminaView(float value) => _stamina.SetAlpha(1 - value);
        public override void SetHealthView(float value) => _health.SetAlpha(1 - value);
        public override void SetSight(SightType type) => _centralSight.SetImage(type);
        public override void SetSightColor(Color color) => _centralSight.SetColor(color);
    }
}
