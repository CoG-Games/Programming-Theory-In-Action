using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet
{
    protected override void Update()
    {
        base.Update();
        HandleMove();
    }
    protected override void HandleMove()
    {
        transform.LookAt(targetPosition);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}
