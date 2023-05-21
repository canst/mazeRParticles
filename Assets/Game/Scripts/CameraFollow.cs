using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Reference to the target object (e.g., the player)

    public float smoothSpeed = 0.125f;  // Speed at which the camera follows the target
    public Vector3 offset;  // Offset distance between the camera and the target

    private void LateUpdate()
    {
        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Update the camera's position
        transform.position = smoothedPosition;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}

