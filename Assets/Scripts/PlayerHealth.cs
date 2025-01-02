using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    private void OnEnable()
    {
        DamageEventSystem.OnBodyPartHit += ApplyDamage;
    }

    private void OnDisable()
    {
        DamageEventSystem.OnBodyPartHit -= ApplyDamage;
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void ApplyDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Damage Taken: {damage}, Current Health: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Died");
        // Handle player death
    }
}
