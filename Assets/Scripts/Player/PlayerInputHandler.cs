using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{
    public PlayerControls Controls;
    public PlayerData playerData;
    public float JumpPressedTime;
    public bool jumpToConsume;  
    public bool jumpReleasedEarly;

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
            playerData.MoveInput = context.ReadValue<Vector2>();
            Debug.Log("Move Input: " + playerData.MoveInput);
        }
        if (context.canceled)
        {
            playerData.MoveInput = Vector2.zero;
            Debug.Log("Move Input Canceled");
        }
    }
    public void JumpInputManager(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpPressedTime = Time.time;
            playerData.JumpInput = true;
            Debug.Log("Jump Started");
            
        }
        else if (context.performed)
        {
            
            
            Debug.Log("Jump Performed");
            
        }
        else if (context.canceled)
        {
            playerData.JumpInput = false;
            Debug.Log("Jump Canceled");
        }
    }

}