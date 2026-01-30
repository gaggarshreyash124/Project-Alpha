using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{
    public PlayerControls Controls;
    public PlayerData playerData;
    public float JumpPressedTime;
    public Vector2 MoveInput;
    public bool JumpInput = false;
    public bool jumpReleasedEarly;
    public float JumpInputHoldTime;


    public bool DashInput;
    void Awake()
    {
        Controls = new PlayerControls();
    }
    void OnEnable()
    {
        Controls.Enable();
    }
    void OnDisable()
    {
        Controls.Disable();
    }

    void Update()
    {
        Controls.Player.Sprint.performed += ctx => DashInput = true;
        Controls.Player.Sprint.canceled += ctx => DashInput = false;

    }
    public void MoveInputManager(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MoveInput = context.ReadValue<Vector2>();
            Debug.Log("Move Input: " + MoveInput);
        }
        if (context.canceled)
        {
            MoveInput = Vector2.zero;
            Debug.Log("Move Input Canceled");
        }
    }
    public void JumpInputManager(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpPressedTime = Time.time;
            JumpInput = true;
            Debug.Log(JumpInput);
            Debug.Log("Jump Started");
        }
        else if (context.performed)
        {
            JumpInput = false;
            jumpReleasedEarly = true;
        }
        else if (context.canceled)
        {
            JumpInput = false;
        }
    }

}