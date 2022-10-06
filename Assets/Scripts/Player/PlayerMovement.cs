using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    
    [Header("AXIS")]
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;

    [Header("Stats")]
    [SerializeField] private Vector3 playerSpeed;

    [Header("Values")]
    [SerializeField] private Vector3 rotationSpeed;
    [SerializeField] private Vector3 currentRotation;

    [SerializeField] private float rotationThreshold;

    [Header("Booleans")]
    [SerializeField] private bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UpdatingAxis();
    }

    private void RotatingPlayer()
    {
        var rotationThresholdX = currentRotation.x < rotationThreshold && currentRotation.x > -rotationThreshold;
        var rotationThresholdZ = currentRotation.z < rotationThreshold && currentRotation.z > -rotationThreshold;
        
        if(rotationThresholdX) currentRotation.x += rotationSpeed.x;

        if(rotationThresholdZ) currentRotation.z += rotationSpeed.z;

        if (!isMoving) currentRotation = Vector3.zero;

        if (horizontal != 0 && currentRotation.x != 0)
        {
            if(currentRotation.x > 0) 
            {
                currentRotation.x *= 0.5f;
            }
            else if(currentRotation.x < 0) 
            {
                currentRotation.x /= 0.5f;
            }
            Debug.Log("X: " + currentRotation.x);
        }

        if (vertical != 0 && currentRotation.x != 0)
        {
            if(currentRotation.z > 0) 
            {
                currentRotation.z *= 0.5f;
            }
            else if(currentRotation.z < 0) 
            {
                currentRotation.z /= 0.5f;
            }
            Debug.Log("Z: " + currentRotation.z);
        }

        transform.rotation = Quaternion.Euler(currentRotation.x, 0, currentRotation.z);
        
        /*var rotationThresholdX = currentRotation.x < rotationThreshold && currentRotation.x > -rotationThreshold;
        var rotationThresholdZ = currentRotation.z < rotationThreshold && currentRotation.z > -rotationThreshold;

        if(!isMoving) return;
        if (rotationThresholdX && horizontal != 0) currentRotation.x += rotationSpeed.x;
        if (rotationThresholdZ && vertical != 0) currentRotation.z += rotationSpeed.z;

        currentRotation.x *= rotationSpeed.x;
        currentRotation.z *= rotationSpeed.z;

        //if (!keyPressed) currentRotation *= 0.1f;

        if (currentRotation.x != 0) currentRotation.x *= 0.88f;
        if (currentRotation.z != 0) currentRotation.z *= 0.88f;

        Debug.Log(currentRotation);
        
        //transform.Rotate(currentRotation);
        Debug.Log(transform.rotation);*/
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * playerSpeed.x,0, vertical * playerSpeed.z);
        RotatingPlayer();
    }

    private void UpdatingAxis()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0) isMoving = true;
        else isMoving = false;
    }
}