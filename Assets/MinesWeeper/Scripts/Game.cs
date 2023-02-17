

using UnityEngine;

public class Game : MonoBehaviour
{
    private Board board;
    public int width = 16, height = 16;
    public int mines = 16;
    public Cell[,] state;
    private bool gameOver;

    private void OnValidate()
    {
        mines = Mathf.Clamp(mines, 0, width * height);   
    }

    private void Awake()
    {
        board = GetComponentInChildren<Board>();
    }

    private void Start()
    {

        NewGame();
        //NewCustomGame();
    }
    public void NewCustomGame()
    {
        state = new Cell[3, 3];
        Cell cell = new Cell();
        cell.position = new Vector3Int(0, 0, 0);
        cell.type = Cell.Type.Empty;
        state[0, 0] = cell;
        Cell cell2 = new Cell();
        cell2.position = new Vector3Int(1, 1, 0);
        cell2.type = Cell.Type.Empty;
        state[1, 1] = cell2;
        Cell cell3 = new Cell();
        cell3.position = new Vector3Int(2, 2, 0);
        cell3.type = Cell.Type.Empty;
        state[2, 2] = cell3;
        board.Draw(state);
        //Camera.main.transform.position = new Vector3(width / 2, height / 2, -10f);
    }


    public void NewGame()
    {
        state = new Cell[width, height];
        gameOver = false;
        GenerateCell();
        GenerateMines();
        GenerateNumber();
        board.Draw(state);
        Camera.main.transform.position = new Vector3(width / 2, height / 2, -10f);
    }
    public void NewGame2(int newWidth, int newHeight, int newMines) {
        width = newWidth;
        height = newHeight;
        mines = newMines;
        NewGame();
    }
    public void RevealMines(bool toogleMines)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = state[x,y];
                if (cell.type == Cell.Type.Mine)
                {

                    cell.revealed = toogleMines;
                    state[x, y] = cell;
                }
            }
        }
        board.Draw(state);

    }

    private void GenerateCell()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = new Cell();
                cell.position = new Vector3Int(x, y, 0);
                cell.type = Cell.Type.Empty;
                state[x, y] = cell;
            }
        }
    }


    private void GenerateMines()
    {
        for (int i = 0; i < mines; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            while (state[x, y].type == Cell.Type.Mine)
            {
                x++;

                if (x >= width)
                {
                    x = 0;
                    y++;

                    if (y >= height)
                    {
                        y = 0;
                    }
                }
            }

            state[x, y].type = Cell.Type.Mine;
        }
    }
    private void GenerateNumber()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = state[x, y];
                if (cell.type == Cell.Type.Mine)
                    continue;

                cell.number = GetNumber(x, y);
                if (cell.number > 0)
                {
                    cell.type = Cell.Type.Number;

                }
                state[x, y] = cell;
            }
        }
    }
    private int GetNumber(int cellX, int cellY)
    {
        int counter = 0;
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int newX = cellX + x;
                int newY = cellY + y;

                if (newX >= width || newY >= height || newX < 0 || newY < 0)
                    continue;

                if (state[newX, newY].type == Cell.Type.Mine)
                {
                    counter++;
                }
            }
        }
        return counter;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NewGame();
        }
        if (!gameOver) 
        {
            if (Input.GetMouseButtonDown(1))
            {
                Flagged();
            }
            else if (Input.GetMouseButtonDown(0))
            {
                Reveal();
            }
        }
       
    }
    private void Reveal()
    {
        Vector3 worldPosMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int clickCell = board.tilemap.WorldToCell(worldPosMouse);
        Cell cell = GetCell(clickCell.x, clickCell.y);
        if (cell.type == Cell.Type.Invalid || cell.revealed || cell.flagged)
            return;


        switch (cell.type)
        {
            case Cell.Type.Mine:
                Explode(cell);
                break;

            case Cell.Type.Empty:
                Flood(cell);
                break;
            default:
                cell.revealed = true;
                state[clickCell.x, clickCell.y] = cell;
                
                break;
        }
        board.Draw(state);
        WinCondition();
    }

    private void Explode(Cell cell)
    {

        gameOver = true;

        cell.exploded = true;
        cell.revealed = true;
        state[cell.position.x, cell.position.y] = cell;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                cell = state[x, y];
                if (cell.type == Cell.Type.Mine)
                {
                    cell.revealed = true;
                    state[x, y] = cell;
                }
            }
        }

    }

    private void WinCondition()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = state[x, y];
                if (cell.type != Cell.Type.Mine && !cell.revealed)
                    return;
            }
        }

        Debug.Log("winner");
        gameOver = true;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = state[x, y];
                if (cell.type  == Cell.Type.Mine )
                {
                    cell.flagged = true;
                    state[x, y] = cell;
                }
            }
        }
    }


    private void Flood(Cell cell)
    {
        if (cell.revealed) return;
        if (cell.type == Cell.Type.Invalid || cell.type == Cell.Type.Mine) return;

        cell.revealed = true;
        state[cell.position.x, cell.position.y] = cell;

        if (cell.type == Cell.Type.Empty)
        {
            Flood(GetCell(cell.position.x - 1, cell.position.y));
            Flood(GetCell(cell.position.x + 1, cell.position.y));
            Flood(GetCell(cell.position.x , cell.position.y - 1));
            Flood(GetCell(cell.position.x , cell.position.y + 1));
        }


    }

    private void Flagged()
    {

        Vector3 worldPosMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int clickCell = board.tilemap.WorldToCell(worldPosMouse);
        Cell cell = GetCell(clickCell.x, clickCell.y);
        //Debug.Log("worldpos" + worldPosMouse);
        //Debug.Log("clickCell" + clickCell);
        //Debug.Log("cell.type" + cell.type);

        if (cell.type == Cell.Type.Invalid || cell.revealed)
            return;

        cell.flagged = !cell.flagged;
        state[clickCell.x, clickCell.y] = cell;
        board.Draw(state);

    }
    private Cell GetCell(int x, int y)
    {
        if (IsValid(x, y))
        {
            return state[x, y];
        }
        else
        {
            return new Cell();
        }
    }
    private bool IsValid(int newX, int newY)
    {
        return newX >= 0 && newY >= 0 && newX < width && newY < height; 
    }
}
