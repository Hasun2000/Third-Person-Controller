using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    //This Controls Camera Movement and Rotation

    [SerializeField] private float mouseSensitivity = 100.0f;
    [SerializeField] private Transform playerBody;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed = 0.125f;
    private float xRotation = 0.0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotateCamera();
        MoveCamera();
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; 

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 0.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        transform.RotateAround(playerBody.position, Vector3.up, mouseX);
        transform.LookAt(playerBody.position);
    }

    void MoveCamera()
    {
        Vector3 desiredPosition = playerBody.transform.position + offset;
        desiredPosition.y = Mathf.Lerp(transform.position.y, desiredPosition.y, smoothSpeed);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }


}
