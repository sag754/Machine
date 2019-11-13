using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour  // create Third Person Camera Class
{
    public Transform lookAt;                   //allows to set what the camera will look like
    public Transform camTransform;             

    private Camera cam;                        //references the camera

    private float distance = 10.0f;            //sets the distance away from the lookAt object
    private float currentX = 0.0f;             //sets the current X position of the camera
    private float currentY = 5.0f;             //sets the current Y position of the camera
    private float sensitivityX = 8f;         //sets how quickly the camera rotates on the X-axis
    private float sensitivityY = 5f;         //sets how quickly the camera rotates on the Y-axis

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;                     // Gets the camera on the scene
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;     //sets camera control on the X-axis to the Mouse X and sensitivity
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;     //sets camera control on the Y-axis to the Mouse Y and sensitivity
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);                      //updates and changes the current camera position based on X, Y, and Z minus set distance
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);   //maintains the LookAt target as the center point for the camera
        camTransform.position = lookAt.position + rotation * dir;        //updates the rotation and position of the camera based off the lookAt target's center point
        camTransform.LookAt(lookAt.position);                            //updates the position of the LookAt target
    }
}
