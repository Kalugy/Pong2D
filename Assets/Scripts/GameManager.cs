using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int playerPoints = 0;
    public int computerPoints = 0;

    public Ball Ball;
    public ComputerPaddle Computer;
    public PlayerPaddle Player;

    public TMP_Text PlayerScore;
    public TMP_Text ComputerScore;
    public GameObject Environment;
    public GameObject MainMenu;
    public void AddPlayerScore()
    {
        playerPoints++;
        PlayerScore.text = playerPoints.ToString();
        ResetGame();
    }
    public void AddComputerScore()
    {
        computerPoints++;
        ComputerScore.text = computerPoints.ToString();
        ResetGame();
    }

    public void ResetGame()
    {
        Ball.ResetPosition();
        Player.ResetPosition();
        Computer.ResetPosition();
        Ball.StartBallForce();
    }

    public void StartNewGame()
    {
        MainMenu.SetActive(false);
        PlayerScore.gameObject.SetActive(true);
        ComputerScore.gameObject.SetActive(true);
        Environment.SetActive(true);
        Ball.StartBallForce();
    }

}
