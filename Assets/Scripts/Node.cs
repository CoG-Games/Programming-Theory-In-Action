using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    [SerializeField] private MeshRenderer nodeRenderer;
    [SerializeField] private Color hoverColor;

    private Color defaultColor;
    private void Start()
    {
        defaultColor = nodeRenderer.material.color;
    }

    private void OnMouseEnter()
    {
        nodeRenderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        nodeRenderer.material.color = defaultColor;
    }
}
