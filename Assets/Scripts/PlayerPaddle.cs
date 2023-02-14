using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE Child
public class PlayerPaddle : Paddle
{
    // ENCAPSULATION
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
        MovePaddle();
    }
    // POLYMORPHISM
    public override void MovePaddle()
    {
        if (direction.sqrMagnitude != 0)
        {
            rigidbody.AddForce(direction * speed);
        }
    }

}
