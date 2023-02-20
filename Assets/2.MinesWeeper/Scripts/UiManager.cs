using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public Game game;

    public TMP_InputField widthInp;
    public TMP_InputField heightInp;
    public TMP_InputField minesInp;

    private bool toggleMines = false;


    public void ResizeBoard()
    {
        game.NewGame2(Int32.Parse(widthInp.text), Int32.Parse(heightInp.text), Int32.Parse(minesInp.text));
    }

    public void RevealMines()
    {
        toggleMines = !toggleMines;
        game.RevealMines(toggleMines);
    }



}
