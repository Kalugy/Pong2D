using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {

        BallC ball = collision.gameObject.GetComponent<BallC>();

        if(ball != null)
        {
            Destroy(gameObject);
        }

    }
}
