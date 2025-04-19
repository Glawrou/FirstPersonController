using System;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    [Serializable]
    public class SoundData
    {
        public string GroundKey;
        public AudioClip[] Audio;

        public AudioClip GetRandomSound()
        {
            return Audio[UnityEngine.Random.Range(0, Audio.Length)];
        }
    }
}
