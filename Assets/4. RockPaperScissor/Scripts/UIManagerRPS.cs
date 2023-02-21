using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerRPS : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject CounterPanel;
    public GameObject ChoosePanel;
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
}
