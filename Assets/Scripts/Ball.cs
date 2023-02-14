using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float speed;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartBallForce();
    }

    public void StartBallForce()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f)
                                      : Random.Range(0.5f, 1f);
        Vector2 force = new Vector2(x, y);
        rigidbody.AddForce(force * speed);
    }

    public void AddingExternalForce(Vector2 force)
    {
        rigidbody.AddForce(force, ForceMode2D.Impulse);
    }

    public void ResetPosition()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.position = Vector2.zero;
    }

}
