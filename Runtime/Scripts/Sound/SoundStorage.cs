using System.Linq;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class SoundStorage : MonoBehaviour
    {
        [SerializeField] private SoundData[] _soundDatas;

        public SoundData GetSoundData(string key)
        {
            if (!_soundDatas.Any(s => s.GroundKey.Equals(key)))
            {
                return null;
            }

            return _soundDatas.FirstOrDefault(s => s.GroundKey.Equals(key));
        }
    }
}
