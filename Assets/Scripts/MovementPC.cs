using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementPC : MonoBehaviour
{
    private Vector3 playerPosition;

    [Header("Stats")]
    [SerializeField] private Vector2 maxPlayerDistance;
    [SerializeField] private Vector2 playerSpeed;

    [Header("Values")]
    [SerializeField] private Vector2 rotationSpeed;
    [SerializeField] private Vector2 currentRotation;

    [SerializeField] private float rotationThreshold;

    [Header("Booleans")]
    [SerializeField] private bool keyPressed;
    

    // Update is called once per frame
    void Update()
    {
        keyPressed = false;
        
        playerPosition.x = transform.position.x;
        playerPosition.z = transform.position.z;

        var rotationThresholdX = currentRotation.x < rotationThreshold && currentRotation.x > -rotationThreshold;
        var rotationThresholdY = currentRotation.y < rotationThreshold && currentRotation.y > -rotationThreshold;
        
        if(rotationThresholdX) currentRotation.x += rotationSpeed.x;

        if(rotationThresholdY) currentRotation.y += rotationSpeed.y;

        if (!keyPressed) currentRotation *= 0.1f;

        if (currentRotation.x != 0) currentRotation.x *= 0.88f;

        if (currentRotation.y != 0) currentRotation.y *= 0.88f;

        transform.rotation = Quaternion.Euler(currentRotation.y, 0, currentRotation.x);

        if (playerPosition.x < maxPlayerDistance.x)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                keyPressed = true;

                transform.position += Vector3.right * Time.deltaTime * playerSpeed.x;
                if (rotationSpeed.x <= 10)
                {
                    rotationSpeed.x -=5;
                }
            }
        }

        if (playerPosition.x > -maxPlayerDistance.x)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                keyPressed = true;

                transform.position += Vector3.left * Time.deltaTime * playerSpeed.x;
                if (rotationSpeed.x <= 10)
                {
                    rotationSpeed.x += 5;
                }
            }
        }

        if (playerPosition.z > -maxPlayerDistance.y -12)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                keyPressed = true;
                
                transform.position += Vector3.back * Time.deltaTime * playerSpeed.y;
                if (rotationSpeed.y <= 5)
                {
                    rotationSpeed.y -=2;
                }
            }
        }
        
        if (playerPosition.z < maxPlayerDistance.y)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                keyPressed = true;
                
                transform.position += Vector3.forward * Time.deltaTime * playerSpeed.y;
                if (rotationSpeed.y <= 5)
                {
                    rotationSpeed.y +=2;
                }
            }
        }
    }
}
