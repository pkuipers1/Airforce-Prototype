using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementPC : MonoBehaviour
{
    private float playerPositionX;
    private float playerPositionY;
    
    [SerializeField] private float maxPlayerX;
    [SerializeField] private float maxPlayerY;
    
    [SerializeField] private float playerSpeedX;
    [SerializeField] private float playerSpeedY;
    
    [SerializeField] private float rotationSpeedX = 0;
    [SerializeField] private float rotationSpeedY = 0;

    [SerializeField] private float rotationX = 0;
    [SerializeField] private float rotationY = 0;

    [SerializeField] private bool keyPressed;
    

    // Update is called once per frame
    void Update()
    {
        keyPressed = false;
        
        playerPositionX = transform.position.x;
        playerPositionY = transform.position.z;
        
        if(rotationX < 60 && rotationX > -60)
        {
            rotationX += rotationSpeedX;    
        }
        
        if(rotationY < 60 && rotationY > -60)
        {
            rotationY += rotationSpeedY;    
        }

        if (!keyPressed)
        {
            rotationSpeedX *= 0.1f;
            rotationSpeedY *= 0.1f;
        }
        
        if (rotationX != 0)
        {
            rotationX *= 0.88f;
            
        }
        
        if (rotationY != 0)
        {
            rotationY *= 0.88f;
            
        }

        transform.rotation = Quaternion.Euler(rotationY, 0, rotationX);

        if (playerPositionX < maxPlayerX)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                keyPressed = true;

                transform.position += Vector3.right * Time.deltaTime * playerSpeedX;
                if (rotationSpeedX <= 10)
                {
                    rotationSpeedX -=5;
                }
            }
        }

        if (playerPositionX > -maxPlayerX)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                keyPressed = true;

                transform.position += Vector3.left * Time.deltaTime * playerSpeedX;
                if (rotationSpeedX <= 10)
                {
                    rotationSpeedX += 5;
                }
            }
        }

        if (playerPositionY > -maxPlayerY)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                keyPressed = true;
                
                transform.position += Vector3.back * Time.deltaTime * playerSpeedY;
                if (rotationSpeedY <= 5)
                {
                    rotationSpeedY -=2;
                }
            }
        }
        
        if (playerPositionY < maxPlayerY)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                keyPressed = true;
                
                transform.position += Vector3.forward * Time.deltaTime * playerSpeedY;
                if (rotationSpeedY <= 5)
                {
                    rotationSpeedY +=2;
                }
            }
        }
    }
}
