using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPC : MonoBehaviour
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
    [SerializeField] private bool keyPressed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        keyPressed = false;

        RotatingPlayer();
        UpdatingAxis();
    }

    private void RotatingPlayer()
    {
        var rotationThresholdX = currentRotation.x < rotationThreshold && currentRotation.x > -rotationThreshold;
        var rotationThresholdZ = currentRotation.z < rotationThreshold && currentRotation.z > -rotationThreshold;

        if (rotationThresholdX) currentRotation.x += rotationSpeed.x;
        if (rotationThresholdZ) currentRotation.z += rotationSpeed.z;

        if (!keyPressed) currentRotation *= 0.1f;

        if (currentRotation.x != 0) currentRotation.x *= 1;
        if (currentRotation.z != 0) currentRotation.z *= 1;

        transform.rotation = Quaternion.Euler(currentRotation.z, 0, currentRotation.x);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * playerSpeed.x,0, vertical * playerSpeed.z);
    }

    private void UpdatingAxis()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
}
