using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet
{
    private void Update()
    {
        HandleMove();
    }
    protected override void HandleMove()
    {
        transform.LookAt(enemyTarget.GetAttackPosition());
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}
