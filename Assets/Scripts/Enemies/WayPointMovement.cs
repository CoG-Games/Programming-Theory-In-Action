using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMovement : MonoBehaviour
{
    [SerializeField] private float targetReachedDistanceThreshold = 0.1f;
    [SerializeField] private float movementSpeed = 1f;

    private WayPointHandler wayPointHandler;
    private Transform targetWayPoint;
    private int currentWayPointIndex;

    private void Start()
    {
        wayPointHandler = GameAssets.instance.wayPointHandler;
        currentWayPointIndex = 0;
        targetWayPoint = wayPointHandler.GetWayPoint(currentWayPointIndex);
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (targetWayPoint == null)
        {
            return;
        }

        Vector3 movementVector = (targetWayPoint.position - transform.position).normalized * movementSpeed * Time.deltaTime;
        transform.Translate(movementVector);

        if (Vector3.Distance(transform.position, targetWayPoint.position) < targetReachedDistanceThreshold)
        {
            currentWayPointIndex++;
            targetWayPoint = wayPointHandler.GetWayPoint(currentWayPointIndex);
        }
    }
}
