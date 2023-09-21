using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTurret : ShootingTurret
{
    [SerializeField] private Transform turretHead;
    [SerializeField] private int initialStrength;

    private Vector3 lastLookDir;
    private Vector3 turretHeadOffset;
    private int strength;

    private void Start()
    {
        strength = initialStrength;
        turretHeadOffset = turretHead.position.y * Vector3.up;
        lastLookDir = Vector3.forward;
    }
    protected override void Shoot()
    {
        Bullet.Create(bulletPrefab, shootingPosition.position, turretHead.rotation, enemyTarget, strength);
    }

    protected override Enemy GetTarget()
    {
        //Update enemyTarget (typeOf: Transform)
        Enemy closestEnemy = Enemy.GetClosestEnemy(nodePosition, maxRange);

        if (enemyTarget != null)
        {
            lastLookDir = enemyTarget.transform.position;
        }
        transform.LookAt(Vector3.ProjectOnPlane(lastLookDir,Vector3.up) + turretHeadOffset);
        return closestEnemy;
    }
}
