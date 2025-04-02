using System.Linq;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class GroundSoundStorage : MonoBehaviour
    {
        [SerializeField] private GroundSoundData[] _groundSoundDatas;

        public GroundSoundData GetGroundSoundData(string key)
        {
            if (!_groundSoundDatas.Any(s => s.GroundKey.Equals(key)))
            {
                return null;
            }

            return _groundSoundDatas.FirstOrDefault(s => s.GroundKey.Equals(key));
        }
    }
}
