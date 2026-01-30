using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Stats")]
    public float MaxHealth = 100;
    public float currentHealth;
    public float Attack;
    
    [Header("InputHandler Data")]
    
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
    

    [Header("Flip Components")]
    public bool isFacingRight;
    public float fD = 1;

    [Header("Dash Components")]
    public float DashDuration;
    public bool CanDash;
    public float DashCooldown;

    [Header("Masks")]
    public bool WallJumpMask;
    public bool DashMask;
    public bool IfarmeMask;
    public bool DoubleHitMask;
    public bool StrengthMask;
    public bool UltMask;
    
}
