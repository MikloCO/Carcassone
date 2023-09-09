using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public float panSpeed = 2.0f;

    private Vector3 lastMousePosition;

    void Update()
    {
        // Check for mouse button down
        if (Input.GetMouseButtonDown(2))
        {
            lastMousePosition = Input.mousePosition;
        }

        // Check for mouse button held down (dragging)
        if (Input.GetMouseButton(2))
        {
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;

            // Calculate the new position based on the mouse drag
            Vector3 newPosition = transform.position - new Vector3(deltaMousePosition.x, deltaMousePosition.y, 0) * panSpeed * Time.deltaTime;

            // Update the camera's position
            transform.position = newPosition;

            // Update the last mouse position for the next frame
            lastMousePosition = Input.mousePosition;
        }
    }
}