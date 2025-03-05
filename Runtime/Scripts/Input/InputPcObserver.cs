using UnityEngine;

namespace naa.FirstPersonController.PlayerInput
{
    public class InputPcObserver : InputObserver
    {
        private const string MouseAsxisKeyX = "Mouse X";
        private const string MouseAsxisKeyY = "Mouse Y";

        private const string MoveAsxisKeyX = "Horizontal";
        private const string MoveAsxisKeyY = "Vertical";

        private void Update()
        {
            MouseInput();
            MoveInput();
        }

        private void MouseInput()
        {
            var mouseDuration = new Vector2(
                Input.GetAxis(MouseAsxisKeyX),
                Input.GetAxis(MouseAsxisKeyY));

            RotateInvoke(mouseDuration * SensitivityRotateHead);
        }

        private void MoveInput()
        {
            var moveDuration = new Vector2(
                Input.GetAxis(MoveAsxisKeyX),
                Input.GetAxis(MoveAsxisKeyY));

            MoveInvoke(moveDuration);
        }
    }
}
