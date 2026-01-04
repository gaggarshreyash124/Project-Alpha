using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControllerData", menuName = "Scriptable Objects/PlayerControllerData")]
public class PlayerControllerData : ScriptableObject
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 15f;
}
