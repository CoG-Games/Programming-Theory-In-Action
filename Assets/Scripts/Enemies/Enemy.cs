using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int strength;
    [SerializeField] protected float visualOffset;

    protected static List<Enemy> enemyList = new List<Enemy>();

    protected HealthSystem healthSystem;

    protected virtual void Awake()
    {
        healthSystem = new HealthSystem(maxHealth);
        enemyList.Add(this);
        Debug.Log(enemyList.Count);
    }

    public static Enemy GetClosestEnemy(Vector3 position, float maxRange)
    {
        Enemy closestEnemy = null;
        foreach(Enemy enemy in enemyList)
        {
            if(enemy.isDead())
            {
                continue;
            }
            float enemyDistance = Vector3.Distance(enemy.transform.position, position);
            if (enemyDistance < maxRange)
            {
                closestEnemy = enemy;
                maxRange = enemyDistance;
            }
        }

        return closestEnemy;
    }

    public Vector3 GetAttackPosition()
    {
        return transform.position + visualOffset * Vector3.up;
    }

    public virtual void Damage(int damageAmount)
    {
        healthSystem.Damage(damageAmount);
        if(isDead())
        {
            DestroySelf();
        }
    }

    public bool isDead()
    {
        return healthSystem.GetHealth() == 0;
    }

    protected virtual void DestroySelf()
    {
        enemyList.Remove(this);
        Destroy(gameObject);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable iDamageable))
        {
            iDamageable.Damage(strength);
            DestroySelf();
        }
    }
}
