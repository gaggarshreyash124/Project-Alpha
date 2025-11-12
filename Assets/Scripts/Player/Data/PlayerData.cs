using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [TitleGroup("Stat Data")]

    [Header("Idle State")]
    [Header("Move State")]
    [Header("Inair State")]
    [Header("Land State")]
    [Header("Hard Land State")]
    [Header("Dash State")]
    public bool IsDashing;
}
