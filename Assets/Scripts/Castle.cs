using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth;

    private HealthSystem healthSystem;
    private void Awake()
    {
        healthSystem = new HealthSystem(maxHealth);
    }

    public void Damage(int damageAmount)
    {
        healthSystem.Damage(damageAmount);
    }
}
