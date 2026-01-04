using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform GroundCheck;
    public Rigidbody2D rb;
    public PlayerInputHandler inputHandler;
    public PlayerData playerData;

    [Header("Jumping")]
    public bool CanUseCoyote;
    public bool CanUseBufferedJump;
     
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.1f, playerData.GroundLayer);
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<PlayerInputHandler>();
    }
    void FixedUpdate()
    {
        if (IsGrounded() && playerData.JumpInput && inputHandler.JumpPressedTime + playerData.JumpBuffer >= Time.time)
        {
            rb.linearVelocityY = playerData.JumpPower;
        }
        Move();
        
    }   

    public void Move()
    {
        rb.linearVelocityX = playerData.MoveInput.x * playerData.MoveSpeed;
    }
    public void ApplyVariableJump()
    {
        if(inputHandler.jumpReleasedEarly && rb.linearVelocityY > 0)
        {
            rb.linearVelocityY -= playerData.JumpEndEarlyGravityModifier * Time.fixedDeltaTime * playerData.FallAcceleration;
        }
    }
    public void onMove(Vector2 value)
    {
        playerData.MoveInput = value;
        transform.Translate(value.x * playerData.MoveSpeed * Time.deltaTime,value.y * playerData.GroundingForce * Time.deltaTime,0);
    }
}
