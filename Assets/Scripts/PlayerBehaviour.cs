using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float smoothTurnTime = 0.1f;
    [SerializeField] private float smoothTurnVelocity;
    [SerializeField] private Transform cam;
    
    private Vector3 moveDirection;
    private Vector3 direction;


    void Update()
    {
        MovePlayer();

    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        direction = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        if(direction.magnitude >= 0.1f){

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, smoothTurnTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

            moveDirection = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed *Time.deltaTime);
        }

        
    }

}
