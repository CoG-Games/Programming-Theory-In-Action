using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointHandler : MonoBehaviour
{
    private List<Transform> wayPointList;

    private void Awake()
    {
        wayPointList = new List<Transform>();
        foreach(Transform wayPoint in transform)
        {
            wayPointList.Add(wayPoint);
        }
    }

    public Transform GetWayPoint(int index)
    {
        if(index >= wayPointList.Count)
        {
            return null;
        }
        return wayPointList[index];
    }
}
