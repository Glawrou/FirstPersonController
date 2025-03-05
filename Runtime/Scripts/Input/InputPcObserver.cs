using UnityEngine;

namespace naa.FirstPersonController.Input
{
    public class InputPcObserver : InputObserver
    {
        private const string MoseAsxisKeyX = "Mouse X";
        private const string MoseAsxisKeyY = "Mouse Y";

        private void Update()
        {
            var mouseDuration = new Vector2(
                UnityEngine.Input.GetAxis(MoseAsxisKeyX),
                UnityEngine.Input.GetAxis(MoseAsxisKeyY));

            if (mouseDuration != Vector2.zero)
            {
                RotateHeadInvoke(mouseDuration * SensitivityRotateHead);
            }
        }
    }
}
