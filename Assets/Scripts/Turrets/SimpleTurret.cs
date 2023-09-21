using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTurret : ShootingTurret
{
    [SerializeField] private Transform turretHead;
    [SerializeField] private int initialStrength = 5;
    [SerializeField] private float rotationSpeed = 10f;

    private Vector3 lastLookDir;
    private Vector3 turretHeadOffset;
    private int strength;

    private void Start()
    {
        strength = initialStrength;
        turretHeadOffset = turretHead.position.y * Vector3.up;
        lastLookDir = turretHead.position + Vector3.left;
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
        Vector3 currentLookDir = turretHead.position + turretHead.forward;
        Vector3 desiredLookDir = Vector3.ProjectOnPlane(lastLookDir, Vector3.up) + turretHeadOffset;
        turretHead.LookAt(Vector3.Slerp(currentLookDir, desiredLookDir, rotationSpeed * Time.deltaTime));
        return closestEnemy;
    }
}
