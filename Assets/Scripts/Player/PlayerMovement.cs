using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private SpriteRenderer visual;
    
    [Header("AXIS")]
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;

    [Header("Stats")]
    [SerializeField] private Vector3 playerSpeed;

    [Header("Values")]
    [SerializeField] private Vector3 rotationSpeed;
    [SerializeField] private Vector3 currentRotation;
    [SerializeField] private float rotationReturner = 0.88f;

    [SerializeField] private float rotationThreshold;

    [Header("Booleans")]
    [SerializeField] private bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        visual = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        UpdatingAxis();
    }

    private void RotatingPlayer()
    {
        var rotationThresholdX = currentRotation.x < rotationThreshold && currentRotation.x > -rotationThreshold;
        var rotationThresholdZ = currentRotation.z < rotationThreshold && currentRotation.z > -rotationThreshold;
        
        if(rotationThresholdX && vertical > 0) currentRotation.x -= rotationSpeed.x;
        else if(rotationThresholdX && vertical < 0) currentRotation.x += rotationSpeed.x;

        if(rotationThresholdZ && horizontal > 0) currentRotation.z += rotationSpeed.z;
        else if(rotationThresholdZ && horizontal < 0) currentRotation.z -= rotationSpeed.z;
        
        if (!isMoving) currentRotation *= rotationReturner;

        var applyAbleRotation = new Vector3(currentRotation.x, currentRotation.z, 0);
        
        visual.transform.localEulerAngles = applyAbleRotation;
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