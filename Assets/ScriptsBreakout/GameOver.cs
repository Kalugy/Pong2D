using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameOver : MonoBehaviour
{
    public UnityEvent gameOver;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallC ball = collision.gameObject.GetComponent<BallC>();

        if (ball != null)
        {
            gameOver.Invoke();
        }
    }
}
