
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardMemory : MonoBehaviour
{

    public Tilemap tilemap;

    

    public Tile tileBlank;
    public Tile tileReveal;
    public Tile tileImg1;
    public Tile tileImg2;
    public Tile tileImg3;
    public Tile tileImg4;
    public Tile tileImg5;
    public Tile tileImg6;


    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void Draw(CellMemory[,] state)
    {

        int width = state.GetLength(0);
        int height = state.GetLength(1);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), GetTile(state[x,y]));
            }
        }
    }

    private Tile GetTile(CellMemory cell)
    {
        if (cell.reveal)
        {
            return GetTileImg(cell);
        }
        else
        {
            return tileBlank;
        }
    }

    private Tile GetTileImg(CellMemory cell)
    {
        switch (cell.name)
        {
            case "burger": return tileImg1;
            case "fries": return tileImg2;
            case "hotdog": return tileImg3;
            case "icecream": return tileImg4;
            case "milkshake": return tileImg5;
            case "pizza": return tileImg6;
            default : return tileBlank;
        }
    }
}
