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
    
    // Update is called once per frame
    void Update()
    {
        playerPositionX = transform.position.x;
        playerPositionY = transform.position.z;

        if (playerPositionX < maxPlayerX)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * Time.deltaTime * playerSpeedX;
            }
        }

        if (playerPositionX > -maxPlayerX)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * Time.deltaTime * playerSpeedX;
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
