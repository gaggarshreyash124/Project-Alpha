using UnityEngine;


public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerStats Stats;
    public PlayerInputHandler InputHandler;
    public Animator Animator { get; private set; }
    public Rigidbody2D RB;

    private Vector2 Workspace;
    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
    }

    void Update()
    {
        RB.linearVelocity = new Vector2(InputHandler.MoveInput.x * Stats.MoveSpeed, RB.linearVelocityY);
    }

    public void SetVelocityX(float velocity)
    {
        Workspace.Set(velocity, RB.linearVelocity.y);
        RB.linearVelocity = Workspace;
    }
}
