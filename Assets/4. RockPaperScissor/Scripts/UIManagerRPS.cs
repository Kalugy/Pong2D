using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerRPS : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject CounterPanel;
    public GameObject ChoosePanel;
    public GameObject MatchPanel;

    public CounterRPS counter;
    public MatchRPS matchrps;


    public Animator animMatch;
    public Animator animPlayer;
    public Animator animComputer;
    public Animator animPlayerTXT;
    public Animator animComputerTXT;

    public void ChangeFirstScene()
    {
        StartPanel.SetActive(false);
        CounterPanel.SetActive(true);
    }
    public void ChangeScondScene()
    {
        CounterPanel.SetActive(false);
        ChoosePanel.SetActive(true);
    }
    public void ChangeThirdcene()
    {
        ChoosePanel.SetActive(false);
        MatchPanel.SetActive(true);
        matchrps.StartNew();
    }

    public void SecondSceneRestar()
    {
        CounterPanel.SetActive(true);
        MatchPanel.SetActive(false);
        counter.StartScene();
        animMatch.SetTrigger("test");
        animPlayerTXT.SetTrigger("changeagain");
        animComputerTXT.SetTrigger("changeagain");

        animPlayer.SetTrigger("backtoiddle");
        animComputer.SetTrigger("backtoiddle");
    }

}
