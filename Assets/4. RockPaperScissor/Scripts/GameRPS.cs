
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameRPS : MonoBehaviour
{

    public Button btnPaper;
    public Button btnRock;
    public Button btnScissor;

    public const string option1 = "paper";
    public const string option2 = "rock";
    public const string option3 = "scissors";

    public string resultMatch;
    public string computerMatch;
    public string playerMatch;

    // Start is called before the first frame update
    void Start()
    {
        btnPaper.onClick.AddListener(delegate { ChoosePlayer(option1); });
        btnRock.onClick.AddListener(delegate { ChoosePlayer(option2); });
        btnScissor.onClick.AddListener(delegate { ChoosePlayer(option3); });
    }

    private void ChoosePlayer(string playerOption)
    {
        computerMatch = ChooseComputer();
        playerMatch = playerOption;
        Debug.Log("option " + playerOption + "computerOption " + computerMatch);
        //CompareOptions(playerOption, computerOption);
        string result = GetResults(playerOption, computerMatch);
        Debug.Log("result " + result);
        resultMatch = result;
    }

    public string GetResult()
    {
        return resultMatch;
    }

    public void Test()
    {
        Debug.Log("Test");
    }

    //Compared switch 
    private void CompareOptions(string playerOption, string ComputerOption)
    {
        switch (playerOption)
        {
            case option1:
                switch (ComputerOption)
                {
                    case option2: Debug.Log("Win"); break;
                    case option1: Debug.Log("Equal"); break;
                    case option3: Debug.Log("Lose"); break;
                }
                break;
            case option2: 
                switch (ComputerOption) {
                    case option2: Debug.Log("Equal"); break;
                    case option1: Debug.Log("Lose"); break;
                    case option3: Debug.Log("Win"); break;
                }
                break;
            case option3:
                switch (ComputerOption)
                {
                    case option2: Debug.Log("Lose"); break;
                    case option1: Debug.Log("Win"); break;
                    case option3: Debug.Log("Equal"); break;
                }
                break;
        }
    }

    private string GetResults(string userChoice,string computerChoice){
        switch (userChoice + computerChoice)
        {
            case "scissorspaper":
            case "rockscissors":
            case "paperrock":
                return "WIN";
            case "paperscissors":
            case "scissorsrock":
            case "rockpaper":
                return "LOSE";
            case "scissorsscissors":
            case "rockrock":
            case "paperpaper":
                return "DRAW";
            default: return "error";
        }
    }


    private string ChooseComputer()
    {
        int randomOption = Random.Range(0, 3);

        switch (randomOption)
        {
            case 0: return option2;
            case 1: return option1;
            case 2: return option3;
            default: return "No Option";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
