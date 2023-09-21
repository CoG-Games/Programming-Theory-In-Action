using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingTurret : MonoBehaviour
{
    [SerializeField] protected Transform bulletPrefab;
    [SerializeField] protected Transform shootingPosition;
    [SerializeField] protected float timeToBetweenShots = 1f;
    [SerializeField] protected float maxRange = 3f;

    protected Enemy enemyTarget;
    protected float timeToShoot;
    protected Vector3 nodePosition;

    protected virtual void Awake()
    {
        timeToShoot = 0f;
        nodePosition = new Vector3(transform.position.x, 0f, transform.position.z);
    }

    protected virtual void Update()
    {
        enemyTarget = GetTarget();
        if(timeToShoot <=0)
        {
            if (enemyTarget != null)
            {
                Shoot();
                timeToShoot = timeToBetweenShots;
            }
        }
        else
        {
            timeToShoot -= Time.deltaTime;
        }
    }

    protected abstract void Shoot();

    protected abstract Enemy GetTarget();

}
