using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayOneShot : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private const float MaxVolume = 1f;

        public void Play(AudioClip audio)
        {
            Play(audio, MaxVolume);
        }

        public void Play(AudioClip audio, float volume)
        {
            _audioSource.PlayOneShot(audio, volume);
        }
    }
}
