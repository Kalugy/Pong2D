using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE Child
public class ComputerPaddle : Paddle
{
    public Rigidbody2D ball;
    private void FixedUpdate()
    {
        MovePaddle();
    }
    // POLYMORPHISM
    public override void MovePaddle()
    {
        if (ball.velocity.x < 0)
        {
            if (ball.position.y > transform.position.y)
            {
                rigidbody.AddForce(Vector2.up * speed);
            }
            else if (ball.position.y < transform.position.y)
            {
                rigidbody.AddForce(Vector2.down * speed);
            }
        }
        else
        {
            // Move towards the center of the field and idle there until the
            // ball starts coming towards the paddle again
            if (rigidbody.position.y > 0f)
            {
                rigidbody.AddForce(Vector2.down * speed);
            }
            else if (rigidbody.position.y < 0f)
            {
                rigidbody.AddForce(Vector2.up * speed);
            }
        }
    }
}    
