using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    [SerializeField] private MeshRenderer nodeRenderer;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Transform turretSpawnPoint;

    private Color defaultColor;
    private Turret turret;
    private void Start()
    {
        turret = null;
        defaultColor = nodeRenderer.material.color;
    }

    private void OnMouseEnter()
    {
        SetHoverColor();
    }

    private void OnMouseExit()
    {
        SetDefaultColor();
    }

    public void SetHoverColor()
    {
        nodeRenderer.material.color = hoverColor;
    }

    public void SetDefaultColor()
    {
        nodeRenderer.material.color = defaultColor;
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            return;
        }
        turret = Turret.Create(GameAssets.instance.simpleTurretPrefab, turretSpawnPoint.position, this);
    }
}
