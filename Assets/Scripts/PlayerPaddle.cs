using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle
{
    public Vector2 direction { get; private set; }
    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else
        {
            direction = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        if(direction.sqrMagnitude != 0)
        {
            rigidbody.AddForce(direction * speed);
        }
    }
    

}
