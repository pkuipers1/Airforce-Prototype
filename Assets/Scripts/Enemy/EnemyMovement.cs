using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float destinationZ;
    [SerializeField] private float destinationX;

    [SerializeField] private float movementSpeedZ;
    [SerializeField] private float movementSpeedX;

    [SerializeField] private bool movingRight;
    
    // Start is called before the first frame update
    void Start()
    {
        movingRight = true;
        transform.Rotate(90f, 0f, 0f);
    }

    private void Update()
    {
        if (transform.position.z >= destinationZ)
        {
            MoveDown(destinationZ);
        }
        
        if (transform.position.z <= destinationZ && movingRight)
        {
            MoveRight(destinationX);
        }

        else if(!movingRight)
        {
            MoveLeft(destinationX);
        }
    }

    void MoveDown(float moveZ)
    {
        transform.Translate(0f, -1f * Time.deltaTime * movementSpeedZ, 0f);
    }

    void MoveRight(float moveX)
    {
        transform.Translate(1f * Time.deltaTime * movementSpeedX, 0f, 0f);
        if(destinationX <= transform.position.x)
        {
            movingRight = false;
        }
    }

    void MoveLeft(float moveX)
    {
        transform.Translate(-1f * Time.deltaTime * movementSpeedX, 0f, 0f);
        if(destinationX <= -transform.position.x)
        {
            movingRight = true;
        }
    }
}
