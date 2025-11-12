using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{

    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool DashPressed { get; private set; }
    public bool AttackPressed { get; private set; }

    public PlayerControls inputActions;

    private void Awake()
    {
        inputActions = new PlayerControls();

        // Subscribe to Input System events
        inputActions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => MoveInput = Vector2.zero;
        inputActions.Player.Jump.performed += ctx => JumpPressed = true;
        inputActions.Player.Jump.canceled += ctx => JumpPressed = false;

        inputActions.Player.Dash.performed += ctx => DashPressed = true;
        inputActions.Player.Dash.canceled += ctx => DashPressed = false;

        inputActions.Player.Attack.performed += ctx => AttackPressed = true;
        inputActions.Player.Attack.canceled += ctx => AttackPressed = false;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        // Movement logic
        Vector3 move = new Vector3(MoveInput.x, 0, MoveInput.y);
        transform.Translate(move * Time.deltaTime * 5f);

        // Jump logic
        if (JumpPressed)
        {
            Debug.Log("Jump!");
            JumpPressed = false; // Reset so jump only once per press
        }

        // Dash logic
        if (DashPressed)
        {
            Debug.Log("Dash!");
            DashPressed = false;
        }

        // Attack logic
        if (AttackPressed)
        {
            Debug.Log("Attack!");
            AttackPressed = false;
        }
    }
    
}
