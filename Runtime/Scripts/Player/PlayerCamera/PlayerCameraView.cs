using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public abstract class PlayerCameraView : MonoBehaviour
    {
        public abstract void SetRun(bool isRun);
        public abstract void SetStaminaView(float value);
        public abstract void SetHealthView(float value);
        public abstract void SetSight(SightType type);
        public abstract void SetSightColor(Color color);
    }
}
