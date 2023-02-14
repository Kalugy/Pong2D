using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public PlayerController player;

    public BallC ball;


    public void GameOver()
    {
        ball.ResetBall();
    }



}
