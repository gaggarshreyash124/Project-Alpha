using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{
    public PlayerInput Controls;
    public PlayerData playerData;
    public float JumpPressedTime;
    public bool jumpToConsume;  
    public bool jumpReleasedEarly;
    public bool JumpCancelled;
    void Awake()
    {
        Controls = GetComponent<PlayerInput>();
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
            Debug.Log("Jump Started");
            
        }
        else if (context.performed)
        {
            playerData.JumpInput = true;
            jumpToConsume = true;
            Debug.Log("Jump Performed");
            
        }
        else if (context.canceled)
        {
            playerData.JumpInput = false;
            Debug.Log("Jump Canceled");
        }
    }
    void Update()
    {
        if (JumpPressedTime + 0.01f >= Time.time && JumpCancelled)
        {
            jumpReleasedEarly = true;
        }
        else
        {
            jumpReleasedEarly = false;
        }
    } 

}