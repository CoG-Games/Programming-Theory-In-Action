using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float movementSpeed;

    protected Enemy enemyTarget;
    protected int bulletStrength;

    public static void Create(Transform bulletPrefab, Vector3 spawnPosition, Quaternion rotation, Enemy enemyTarget, int bulletStrength)
    {
        Transform bulletTransform = Instantiate(bulletPrefab, spawnPosition, rotation);
        Bullet bullet = bulletTransform.GetComponent<Bullet>();
        bullet.Setup(enemyTarget, bulletStrength);
    }

    protected abstract void HandleMove();

    protected virtual void Setup(Enemy enemyTarget, int bulletStrength)
    {
        this.enemyTarget = enemyTarget;
        this.bulletStrength = bulletStrength;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Enemy>(out Enemy enemy) && enemy == enemyTarget)
        {
            enemy.Damage(bulletStrength);
            Destroy(gameObject);
        }
    }
}
