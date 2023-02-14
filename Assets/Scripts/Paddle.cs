using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected new Rigidbody2D rigidbody;
    public float speed = 4f;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();   
    }

    public void ResetPosition()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.position = new Vector2(rigidbody.position.x, 0f);
    }
}
