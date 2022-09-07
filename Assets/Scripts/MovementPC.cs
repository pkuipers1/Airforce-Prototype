using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementPC : MonoBehaviour
{
    public float playerPositionX;
    public float playerPositionY;
    // Update is called once per frame
    void Update()
    {
        playerPositionX = transform.position.x;
        playerPositionY = transform.position.y;

        if (playerPositionX < 2.45)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * Time.deltaTime * 3f;
            }
        }

        if (playerPositionX > -2.45)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * Time.deltaTime * 3f;
            }
        }

        if (playerPositionY > -4.25)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.down * Time.deltaTime * 2.5f;
            }
        }
        
        if (playerPositionY < 4.25)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.up * Time.deltaTime * 3.5f;
            }
        }
    }
}
