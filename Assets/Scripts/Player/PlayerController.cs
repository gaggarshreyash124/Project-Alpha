using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour,IDamagable
{
    public Transform GroundCheck;
    public Rigidbody2D rb;
    public PlayerInputHandler inputHandler;
    public PlayerData playerData; 
    public BoxCollider2D boxc;
    public LayerMask EnemyLayer;
    public bool touchedenemy;
    bool isknockingback = false;
    // Cayotee/buffer jump
    bool CanUseCoyote => playerData.cancayotee && !playerData.isGrounded && Time.time < playerData.cayoteecheck + playerData.CoyoteTime;
    bool HasBufferedJump => playerData.canbuffer && Time.time < inputHandler.JumpPressedTime + playerData.JumpBuffer;
    bool GroundHit()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.1f, playerData.GroundLayer);
    }
    public bool IsTouchingEnemy(out EnemyController Escript)
    {
        Escript = null;

        Collider2D Hit = Physics2D.OverlapBox(boxc.bounds.center,boxc.bounds.size,0,EnemyLayer);
        if (Hit == null)
        {
            return false;
        }

        Escript = Hit.GetComponent<EnemyController>();
        return Escript != null;
    }

    public float KnockbackPower = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxc = GetComponent<BoxCollider2D>();
        inputHandler = GetComponent<PlayerInputHandler>();
        
    }

    void Start()
    {
        playerData.currentHealth = playerData.MaxHealth;
    }
    void Update()
    {
        
        if(inputHandler.MoveInput.x > 0 && playerData.isFacingRight && playerData.fD == -1)
        {
            Flip();
            
        }
        else if(inputHandler.MoveInput.x < 0 && !playerData.isFacingRight && playerData.fD == 1)
        {
            Flip();
        }

        if (inputHandler.DashInput && playerData.CanDash)
        {
            StartCoroutine(Dash(playerData.DashDuration,playerData.DashSpeed,playerData.DashCooldown));
        }
        Debug.Log(IsTouchingEnemy(out EnemyController escript));
        if (IsTouchingEnemy(out EnemyController enemy) && !touchedenemy)
        {
            touchedenemy = true;
            StartCoroutine(KnockbackCoroutine());
        }
        else if (!IsTouchingEnemy(out enemy) && touchedenemy)
        {
            touchedenemy = false;
        }
    }
    
    void FixedUpdate()
    {
        if (!isknockingback)
        {
            Move();
        }
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
        rb.linearVelocityX = inputHandler.MoveInput.x * playerData.MoveSpeed;
    }

    public void Jump()
    {
        if(!inputHandler.JumpInput && !HasBufferedJump) return;  
        
        if (playerData.isGrounded || CanUseCoyote)
        {
            playerData.cancayotee = false;
            playerData.canbuffer = false;
            rb.linearVelocityY = playerData.JumpPower * 100 * Time.fixedDeltaTime;
            inputHandler.JumpInput = false;
        
        }
    }

    public void Flip()
    {
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        playerData.fD *= -1;
        transform.localScale = Scale;
        playerData.isFacingRight = !playerData.isFacingRight;
    }

    public IEnumerator Dash(float dashDuration, float dashSpeed, float Cooldown)
    {
        float elapsed = 0f;

        while (elapsed < dashDuration)
        {
            rb.linearVelocityX = dashSpeed;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
    public void TakeDamage(float Damage)
    {
        playerData.currentHealth -= Damage;

        if (playerData.currentHealth <= 0 )
        {
            Debug.Log("Dead Man");
        }
    }

    public IEnumerator DelayTime(float DelayTime)
    {
        yield return new WaitForSeconds(DelayTime);
    }

    IEnumerator KnockbackCoroutine()
{
    isknockingback = true;
    Vector2 force = new Vector2((playerData.fD * -1) * KnockbackPower,.2f);
    rb.linearVelocity = Vector2.zero;
    rb.AddForce(force, ForceMode2D.Impulse);

    yield return new WaitForSeconds(.2f);
    isknockingback = false;
    
}
}

public interface IDamagable
{    
    public void TakeDamage(float Damage);
}