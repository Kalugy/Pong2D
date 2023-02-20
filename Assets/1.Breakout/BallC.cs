using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallC : MonoBehaviour
{
    private Rigidbody2D BallRigidBody;
    public float speed;
    private void Awake()
    {
        BallRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartMovement();
    }
    public void StartMovement()
    {
        float x = 0.2f;
        float y = -1;

        Vector2 movement = new Vector2(x, y);
        BallRigidBody.AddForce(movement * speed);

    }

    public void ResetBall()
    {
        BallRigidBody.position = Vector2.zero;
        BallRigidBody.velocity = Vector2.zero;

    }
}
