using Sirenix.OdinInspector;
using Sirenix.Serialization.Utilities.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [TitleGroup("Stats")]
    public float MaxHealth = 100f;
    public float Defense = 10f; // Also Known as Armor
    public float AttackDamage = 25f;
    public float ArcanaMax = 50f;
    public float MoveSpeed = 5f;
    public float JumpForce = 10f;
    public float CriticalHitMultiplier = 1.5f;
    public float CriticalHitChance = 0.1f;
    public float AttackSpeed = 1f;
    [TitleGroup("Current Stats")]
    public float CurrentHealth = 100f;
    public float CurrentArcana = 50f;

    [TitleGroup("Hidden Stats")]
    public float TrueDefense = 5f; // Does not get reduced by armor penetration
    public float DefensePenetration = 0f;
    public float KnockbackResistance = 0.5f;

    [TitleGroup("Ability Stats")]
    public float DashCooldown = 2f;
    public float DashDistance = .2f; //also known as dash Time

    [TitleGroup("Attack Stats")]
    public float AttackRange = 1.5f;
    public float KnockbackForce = 10f;

    [TitleGroup("Regeneration Stats")]
    public float HealthRegenRate = 1f;
    public float ArcanaRegenRate = 0.5f;
}
