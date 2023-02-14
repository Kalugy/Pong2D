using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    public GameObject[] PrefabEnemy;

    private void Start()
    {
        GenerateEnemies();
    }

    public void GenerateEnemies()
    {
        int Width = Screen.width;
        int Height = Screen.width - 10;
        int number;
        for (int j = 4; j > 0; j--)
        { 
            for (int i = -7; i < 10; i = i + 3)
            {
                number = Random.Range(0, PrefabEnemy.Length);
                Instantiate(PrefabEnemy[number], new Vector2(i, j), PrefabEnemy[number].transform.rotation);
            }
        }
        


    }

}
