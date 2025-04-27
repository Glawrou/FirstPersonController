using UnityEngine;

namespace naa.FirstPersonController.PlayerInput
{
    public class InputPcObserver : InputObserver
    {
        [Header("Keys")]
        [SerializeField] private KeyCode _keyJump;
        [SerializeField] private KeyCode _keyRun;
        [SerializeField] private KeyCode _keySneaking;
        [SerializeField] private KeyCode _keyUse;

        private const string MouseAsxisKeyX = "Mouse X";
        private const string MouseAsxisKeyY = "Mouse Y";

        private const string MoveAsxisKeyX = "Horizontal";
        private const string MoveAsxisKeyY = "Vertical";

        private void Update()
        {
            MouseInput();
            MoveInput();
            RunInput();
            SneakingInput();
            JumpInput();
            UseInput();
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

        private void JumpInput()
        {
            if (Input.GetKeyDown(_keyJump))
            {
                JumpInvoke();
            }
        }

        private void SneakingInput()
        {
            if (Input.GetKeyDown(_keySneaking))
            {
                SneakingInvoke(true);
            }
            else if (Input.GetKeyUp(_keySneaking))
            {
                SneakingInvoke(false);
            }
        }

        private void RunInput()
        {
            if (Input.GetKeyDown(_keyRun))
            {
                RunInvoke(true);
            }
            else if (Input.GetKeyUp(_keyRun))
            {
                RunInvoke(false);
            }
        }

        private void UseInput()
        {
            if (Input.GetKeyDown(_keyUse))
            {
                UseInvoke(true);
            }
            else if (Input.GetKeyUp(_keyUse))
            {
                UseInvoke(false);
            }
        }
    }
}
