using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("InputHandler Data")]
    public Vector2 MoveInput;
    public bool JumpInput = false;
    public float JumpInputHoldTime;

    [Header("Movement Variables")] 
    public float MoveSpeed = 14;
    public float JumpPower = 36;
    public float DashSpeed;

    [Header("Jump Components")]
    //Grounded
    public LayerMask GroundLayer;
    public bool isGrounded;
    //Cayotee
    public float cayoteecheck;
    public bool cancayotee;
    public float CoyoteTime = .15f;
    //Buffer
    public bool canbuffer;
    public float JumpBuffer = .2f;

    [Header("Masks")]
    public bool WallJumpMask;
    public bool DashMask;
    public bool IfarmeMask;
    public bool DoubleHitMask;
    public bool StrengthMask;
    public bool UltMask;
    
}
