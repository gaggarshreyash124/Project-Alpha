using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform GroundCheck;
    public Rigidbody2D rb;
    public PlayerInputHandler inputHandler;
    public PlayerData playerData; 
    
    //Flip
    public bool isFacingRight;

    
    bool CanUseCoyote => playerData.cancayotee && !playerData.isGrounded && Time.time < playerData.cayoteecheck + playerData.CoyoteTime;
    bool HasBufferedJump => playerData.canbuffer && Time.time < inputHandler.JumpPressedTime + playerData.JumpBuffer;
    bool GroundHit()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.1f, playerData.GroundLayer);
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<PlayerInputHandler>();
        
    }
    void Update()
    {
        if(playerData.MoveInput.x > 0 && isFacingRight)
        {
            Flip();
        }
        else if(playerData.MoveInput.x < 0 && !isFacingRight)
        {
            Flip();
        }

        if (inputHandler.DashInput)
        {
            StartCoroutine(Dash());
        }
    }
    void FixedUpdate()
    {
        Move();
        Jump();

        if (!playerData.isGrounded && GroundHit())
        {
            playerData.isGrounded = true;
            playerData.cancayotee = true;
            playerData.canbuffer = true;
        }
        else if (playerData.isGrounded && !GroundHit())
        {
            playerData.isGrounded = false;
            playerData.cayoteecheck = Time.time;
        }
    }

    public void Move()
    {
        rb.linearVelocityX = playerData.MoveInput.x * playerData.MoveSpeed;
    }

    public void Jump()
    {
        if(!playerData.JumpInput && !HasBufferedJump) return;  
        
        if (playerData.isGrounded || CanUseCoyote)
        {
            
            playerData.cancayotee = false;
            playerData.canbuffer = false;
            rb.linearVelocityY = playerData.JumpPower * 100 * Time.fixedDeltaTime;
        }
    }

    public void Flip()
    {
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
        isFacingRight = !isFacingRight;
    }

    public IEnumerator Dash(float dashDuration, float dashSpeed)
    {
        float elapsed = 0f;

        while (elapsed < dashDuration)
        {
            rb.linearVelocityX = dashSpeed;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
    
}
