using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class PlayerSound : MonoBehaviour
    {
        [SerializeField] private SoundStorage _storage;
        [SerializeField] private PlayerTriggerGround _triggerGround;
        [SerializeField] private PlayOneShot _legs;
        [SerializeField] private PlayOneShot _head;

        private const string JumpKey = "Jump";

        public void PlayJump()
        {
            _head.Play(_storage.GetSoundData(JumpKey).GetRandomSound());
        }

        public void PlayStep(float volume)
        {
            if (_triggerGround.CurrentGround == null)
            {
                return;
            }

            PlayStep(_triggerGround.CurrentGround.GroundKey, volume);
        }

        public void PlayStep(string key, float volume)
        {
            var soundData = _storage.GetSoundData(key);
            if (soundData == null)
            {
                return;
            }

            _legs.Play(soundData.GetRandomSound(), volume);
        }
    }
}
