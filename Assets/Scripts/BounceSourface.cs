using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSourface : MonoBehaviour
{
    public float strength = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if(ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddingExternalForce(-normal * strength);
        }
    }
}
