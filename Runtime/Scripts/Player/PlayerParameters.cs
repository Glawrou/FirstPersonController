using System;

[Serializable]
public class PlayerParameters
{
    public float MoveSpeed = 5;
    public float RunFactor = 1.5f;
    public float SneakingFactor = 0.4f;
    public float Stamina = 10;
    public float ForceJump = 5;
    public bool IsDoubleJump = false;
}