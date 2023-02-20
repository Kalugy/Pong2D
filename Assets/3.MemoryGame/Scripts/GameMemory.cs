using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMemory : MonoBehaviour
{

    private BoardMemory board;

    CellMemory[,] state;

    public int width = 4;
    public int height = 3;
    [SerializeField]
    private int counterTwoClicks = 0;
    private CellMemory[] cellStates = new CellMemory[2];

    public bool reveal = false;

    [SerializeField]
    private float score = 0;
    [SerializeField]
    private float timeRemaining = 30;
    [SerializeField]
    private bool  timerIsRunning = true;

    private bool toogleDebugPanel;
    public GameObject DebugPanel;

    public UIManagerMemory UIManager;

    void Awake()
    {
        board = GetComponentInChildren<BoardMemory>();

        Camera.main.transform.position = new Vector3(width / 2, 1.5f, -10);
    }

    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        state = new CellMemory[width,height];
        GenerateEmpty();
        GenerateImgs();
        UIStartGame();
        board.Draw(state);
    }

    private void UIStartGame()
    {
        UIManager.HidePanelStateGame();
        timerIsRunning = true;
        score = 0;
        timeRemaining = 30;
        UIManager.DisplayScore(score.ToString());
        UIManager.DisplayTime(timeRemaining.ToString());
    }

    private void GenerateEmpty()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                CellMemory cell = state[x, y];
                cell.position = new Vector3Int(x,y,0);
                cell.type = CellMemory.Type.Empty;
                state[x, y] = cell;
            }
        }
    }
    private void GenerateImgs()
    {
        int[] randomArray = GenerateRandomArrayWithTwoOccurancesOfEachNumber(width * height, width * height / 2);
        int count = 0;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                CellMemory cell = state[x, y];
                cell.name = SetNameByNumber(randomArray[count]);
                count++;
                cell.type = CellMemory.Type.Object;
                state[x, y] = cell;
            }
        }
        
    }
    

    public int[] GenerateRandomArrayWithTwoOccurancesOfEachNumber(int length, int maxValue)
    {
        if (length % 2 != 0)
        {
            Debug.LogError("Array length must be an even number");
            return null;
        }

        List<int> numbers = new List<int>();
        for (int i = 1; i <= maxValue; i++)
        {
            numbers.Add(i);
            numbers.Add(i);
        }

        int[] result = new int[length];
        for (int i = 0; i < length; i++)
        {
            int index = Random.Range(0, numbers.Count);
            result[i] = numbers[index];
            numbers.RemoveAt(index);
        }

        return result;
    }


    private string SetNameByNumber(int randomNumber)
    {
        switch (randomNumber)
        {
            case 1: return "burger";
            case 2: return "fries";
            case 3: return "hotdog";
            case 4: return "icecream";
            case 5: return "milkshake";
            case 6: return "pizza";
            default: return "burger";
        }
    }

    private void Update()
    {
        
        if (timerIsRunning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                UnlockSelection();
            }
            if (timeRemaining > 0)
            {
               
                timeRemaining -= Time.deltaTime;
                float minutes = Mathf.FloorToInt(timeRemaining);
                UIManager.DisplayTime(minutes.ToString());
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                UIManager.DisplayTime("0");
                UIManager.NewRestartGame("Lose! :(");
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            toogleDebugPanel = !toogleDebugPanel;
            DebugPanel.SetActive(toogleDebugPanel);
        }
    }

    

    private void UnlockSelection()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = board.tilemap.WorldToCell(worldPos);
        CellMemory cell = GetCell(cellPos.x, cellPos.y);

        if (cell.type == CellMemory.Type.Invalid)
            return;

        cell.reveal = true;
        state[cellPos.x, cellPos.y] = cell;

        ComparesTwoCells(cell);

        IsWinnerState();

        board.Draw(state);
    }

    private void IsWinnerState()
    {
        if(score == width * height / 2)
        {
            UIManager.NewRestartGame("Winner! :D");
            timerIsRunning = false;
        }
    }

    private void ComparesTwoCells(CellMemory cell)
    {
        cellStates[counterTwoClicks] = cell;
        if (counterTwoClicks >= 1)
        {
            ValidateEqualImgs(cellStates);
            counterTwoClicks = 0;
        }
        else
        {
            counterTwoClicks++;
        }
    }


    private void ValidateEqualImgs(CellMemory[] cellStates)
    {
        if (cellStates[0].name == cellStates[1].name)
        {
            score++;
            UIManager.DisplayScore(score.ToString());
        }
        else
        {
            StartCoroutine(UnfoldTargets(cellStates));
            
        }
    }

    IEnumerator UnfoldTargets(CellMemory[] cellStates)
    {
        yield return new WaitForSeconds(.5f);
        state[cellStates[0].position.x, cellStates[0].position.y].reveal = false;
        state[cellStates[1].position.x, cellStates[1].position.y].reveal = false;
        board.Draw(state);
    }

    private CellMemory GetCell(int x, int y)
    {

        if (IsValid(x,y))
        {
            return state[x, y];
        }
        else
        {
            return new CellMemory();
        }
    }
    private bool IsValid(int newX, int newY)
    {
        return newX >= 0 && newY >= 0 && newX < width && newY < height;
    }

    public void RevealTheBoard()
    {
        reveal = !reveal;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                CellMemory cell = state[x, y];
                cell.reveal = reveal;
                state[x, y] = cell;
            }
        }
        board.Draw(state);
    }
}
