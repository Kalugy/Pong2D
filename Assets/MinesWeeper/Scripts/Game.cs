
using UnityEngine;

public class Game : MonoBehaviour
{
    private Board board;
    public int width = 16, height = 16;
    public int mines = 16;
    public Cell[,] state;

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
        GenerateCell();
        GenerateMines();
        GenerateNumber();
        board.Draw(state);
        Camera.main.transform.position = new Vector3(width / 2, height / 2, -10f);
    }

    private void GenerateCell()
    {
        for(int x=0; x<width; x++)
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

            while(state[x, y].type == Cell.Type.Mine)
            {
                x++;

                if(x >= width)
                {
                    x = 0;
                    y++;

                    if(y >= height)
                    {
                        y = 0;
                    }
                }
            }

            state[x, y].type = Cell.Type.Mine;
            state[x, y].revealed = true;
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

                cell.number = GetNumber(x,y);
                if(cell.number > 0)
                {
                    cell.type = Cell.Type.Number;
                    
                }
                cell.revealed = true;
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

                if(state[newX, newY].type == Cell.Type.Mine)
                {
                    counter++;
                }
            }
        }
        return counter;
    }
}
