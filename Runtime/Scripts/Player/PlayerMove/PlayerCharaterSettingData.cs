using System;
using UnityEngine;

namespace naa.FirstPersonController.Player
{
    [Serializable]
    public class PlayerCharaterSettingData
    {
        public MoveType MoveType;
        public float SteppOffset;
        public Vector3 Center;
        public float Height;
    }
}
