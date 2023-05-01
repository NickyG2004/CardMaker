using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class DragableObject : MonoBehaviour
{
    private Camera mainCamera;
    private float CameraZDistance;

    void Start()
    {
        mainCamera = Camera.main;
        CameraZDistance = mainCamera.WorldToScreenPoint(transform.position).z; // Z axis of the game object for the screen view.
    }

    private void OnMouseDrag()
    {
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance);
        Vector3 NewWorldPosition = mainCamera.ScreenToWorldPoint(ScreenPosition); // Screen point converted to world point
        transform.position = NewWorldPosition;
    }
}


