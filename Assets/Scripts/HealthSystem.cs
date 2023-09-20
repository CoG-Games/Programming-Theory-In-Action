using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    public delegate void death();
    public event death onDead;
    private int health;
    private int maxHealth;

    public HealthSystem(int maxHealthValue)
    {
        maxHealth = maxHealthValue;
        health = maxHealth;
    }

    public void Heal(int healAmount)
    {
        health = Mathf.Min(health + healAmount, maxHealth);
    }

    public void Damage(int damageAmount)
    {
        health = Mathf.Max(health - damageAmount, 0);
        if(health == 0)
        {
            onDead?.Invoke();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>percentage of max health remaining</returns>
    public float GetHealthPercentage()
    {
        return health / (float)maxHealth;
    }
}
