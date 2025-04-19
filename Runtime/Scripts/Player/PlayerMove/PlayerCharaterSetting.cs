using System.Linq;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerCharaterSetting : MonoBehaviour
    {
        [SerializeField] private PlayerCharaterSettingData[] _settingDatas;
        [SerializeField] private PlayerCharaterSettingData _defaultSettingData;
        [SerializeField] private CharacterController _characterController;

        public void Set(MoveType moveType)
        {
            var settings = GetSettingData(moveType);
            _characterController.center = settings.Center;
            _characterController.stepOffset = settings.SteppOffset;
            _characterController.height = settings.Height;
        }

        private PlayerCharaterSettingData GetSettingData(MoveType moveType)
        {
            if (!_settingDatas.Any(s => s.MoveType.Equals(moveType)))
            {
                return _defaultSettingData;
            }

            return _settingDatas.FirstOrDefault(s => s.MoveType.Equals(moveType));
        }
    }
}
