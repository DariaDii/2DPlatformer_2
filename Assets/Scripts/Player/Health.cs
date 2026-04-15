using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    public event Action PlayerDie;
    public event Action Hurt;

    public float HealthAmount { get; private set;  }

    private void Start()
    {
        HealthAmount = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        Hurt?.Invoke();
        HealthAmount -= damage;
        if(HealthAmount<0)
            HealthAmount = 0;
        Debug.Log($"Здоровье: " + HealthAmount);

        if (HealthAmount == 0)
            Die();
    }

    public void Heal(float amount)
    {
        HealthAmount += amount;
        if(HealthAmount>_maxHealth)
            HealthAmount = _maxHealth;

        Debug.Log($"Здоровье: "+ HealthAmount);
    }

    public void Die()
    {
        PlayerDie?.Invoke();
    }
}