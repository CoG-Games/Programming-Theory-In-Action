using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour //INHERITANCE
{
    protected Node node;

    public static Turret Create(Transform turretPrefab, Vector3 spawnPosition, Node node) //ABSTRACTION
    {
        Transform turretTransform = Instantiate(turretPrefab, spawnPosition, turretPrefab.rotation, node.transform);
        Turret turret = turretTransform.GetComponent<Turret>();
        turret.Setup(node);
        return turret;
    }

    protected void Setup(Node node)
    {
        this.node = node;
    }

    protected void OnMouseEnter()
    {
        node.SetHoverColor();
    }
    
    protected void OnMouseExit()
    {
        node.SetDefaultColor();
    }
}
