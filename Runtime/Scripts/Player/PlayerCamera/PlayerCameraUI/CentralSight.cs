using UnityEngine;
using UnityEngine.UI;

namespace naa.FirstPersonController.Player
{
    public class CentralSight : MonoBehaviour
    {
        [SerializeField] private Image _cursor;

        [Space]
        [SerializeField] private Sprite _defaultSight;
        [SerializeField] private Sprite _useSight;

        public void SetImage(SightType type)
        {
            _cursor.enabled = type != SightType.None;
            switch (type)
            {
                case SightType.Default:
                    _cursor.sprite = _defaultSight;
                    break;
                case SightType.Use:
                    _cursor.sprite = _useSight;
                    break;
                default:
                    _cursor.sprite = null;
                    break;
            }
        }

        public void SetColor(Color color)
        {
            _cursor.color = color;
        }
    }
}
