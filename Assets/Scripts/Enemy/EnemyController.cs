using UnityEngine;

public class EnemyController : MonoBehaviour,IDamagable
{
    public float MaxHealth = 20;
    public float currentHealth;
    public float Attack;
    public Rigidbody2D rb;

    void Start()
    {
        currentHealth = MaxHealth;
        
    }
    public void TakeDamage(float Damage)
    {
        currentHealth -= Damage;

        if (currentHealth <= 0 )
        {
            Debug.Log("Dead Man");
        } 
        
    }
}
