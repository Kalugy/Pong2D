
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchRPS : MonoBehaviour
{


    public TMP_Text title;
    public TMP_Text computer;
    public TMP_Text player;

    public Animator animMatch;
    public Animator animPlayer;
    public Animator animComputer;

    public Animator animPlayerTXT;
    public Animator animComputerTXT;

    public GameRPS game;

    public Button btnRestart;

    private void Start()
    {
        animMatch.SetTrigger("animation");
        StartNew();
    }

    public void StartNew()
    {
        player.text = "";
        computer.text = "";
        title.text = "Match";
        title.color = Color.white;
        animMatch.SetTrigger("animation");
        btnRestart.gameObject.SetActive(false);
        StartCoroutine(Delay());
    }

    
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        animPlayer.SetTrigger("doanim");
        animComputer.SetTrigger("doanim2");
        player.text = "rock";
        computer.text = "rock";
        yield return new WaitForSeconds(2f);
        animPlayer.SetTrigger("doanim");
        animComputer.SetTrigger("doanim2");
        player.text = "paper";
        computer.text = "paper";
        yield return new WaitForSeconds(2f);

        animPlayer.SetTrigger("doanimfinal");
        animComputer.SetTrigger("doanimfinal2");
        
        string result = game.GetResult();
        player.text = game.playerMatch;
        computer.text = game.computerMatch;
        
        
        yield return new WaitForSeconds(3f);
        title.text = result;
        
        switch (result)
        {
            case "WIN": title.color = Color.green; break;
            case "LOSE": title.color = Color.red; break;
            case "DRAW": title.color = Color.grey; break;
        }

        animMatch.SetTrigger("animationleft");
        animPlayer.SetTrigger("floatinglefttxt");
        animComputer.SetTrigger("floatingrighttxt");


        yield return new WaitForSeconds(2f);

        animPlayerTXT.SetTrigger("change"); 
        animComputerTXT.SetTrigger("change"); 
        btnRestart.gameObject.SetActive(true);
    }


}
