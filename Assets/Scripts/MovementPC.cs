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
    
    [SerializeField] public float maxRotation;
    [SerializeField] private float rotationSpeed = 0;
    [SerializeField] private float defaultRotation = -90;
    
    [SerializeField] private float rotation = 0;

    [SerializeField] private bool keyPressed;
    

    // Update is called once per frame
    void Update()
    {
        keyPressed = false;
        
        playerPositionX = transform.position.x;
        playerPositionY = transform.position.z;


        if(rotation < 60 && rotation > -60)
        {
            rotation += rotationSpeed;    
        }

        if (!keyPressed)
        {
            rotationSpeed *= 0.1f;
        }
        
        if (rotation != 0)
        {
            rotation *= 0.88f;
            
        }
        
        //Debug.Log("rotation : " + rotation);
        //Debug.Log("rotation speed : " + rotationSpeed);
        
        transform.rotation = Quaternion.Euler(rotation+90,90,-90);
      
        
        
        if (playerPositionX < maxPlayerX)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                keyPressed = true;

                transform.position += Vector3.right * Time.deltaTime * playerSpeedX;
                if (rotationSpeed <= 10)
                {
                    rotationSpeed +=5;
                }
            }
        }

        if (playerPositionX > -maxPlayerX)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                keyPressed = true;

                transform.position += Vector3.left * Time.deltaTime * playerSpeedX;
                if (rotationSpeed <= 10)
                {
                    rotationSpeed -= 5;
                }
            }
        }

        if (playerPositionY > -maxPlayerY)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.back * Time.deltaTime * playerSpeedY;
            }
        }
        
        if (playerPositionY < maxPlayerY)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.forward * Time.deltaTime * playerSpeedY;
            }
        }
    }
}
