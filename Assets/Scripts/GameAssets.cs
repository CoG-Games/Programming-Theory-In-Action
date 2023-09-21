using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance;
    public static GameAssets Instance { get { return instance; } private set { instance = value; } } //ENCAPSULATION

    public WayPointHandler wayPointHandler;

    [Header("Turrets")]
    public Transform simpleTurretPrefab;

    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    
}
