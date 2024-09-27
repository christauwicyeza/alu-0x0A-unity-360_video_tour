using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectM : MonoBehaviour
{
    public float rotationSpeed = 2f;
    private Vector3 lastMousePosition;

    void Update()
    {
        RotateObject();
    }

    void RotateObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float deltaY = currentMousePosition.y - lastMousePosition.y;
            transform.Rotate(0, deltaY * rotationSpeed, 0);
            lastMousePosition = currentMousePosition;
        }
    }
}
