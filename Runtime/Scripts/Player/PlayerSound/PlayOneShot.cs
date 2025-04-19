using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayOneShot : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public void Play(AudioClip audio, float volume)
        {
            _audioSource.PlayOneShot(audio, volume);
        }
    }
}
