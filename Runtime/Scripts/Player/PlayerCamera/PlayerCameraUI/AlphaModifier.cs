using UnityEngine;

namespace naa.FirstPersonController.Player
{
    public class AlphaModifier : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        public void SetAlpha(float value)
        {
            _canvasGroup.alpha = Mathf.Clamp01(value);
        }
    }
}
