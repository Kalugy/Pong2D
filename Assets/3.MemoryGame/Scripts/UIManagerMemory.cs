
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerMemory : MonoBehaviour
{

    public TMP_Text timer;
    public TMP_Text scoreTxt;

    public GameObject StatePanel;
    public TMP_Text titleStatePanel;

    public void DisplayTime(string time)
    {
        timer.text = time;
    }
    public void DisplayScore(string score)
    {
        scoreTxt.text = score;
    }

    public void NewRestartGame(string title)
    {
        titleStatePanel.text = title;
        StatePanel.SetActive(true);
    }

    public void HidePanelStateGame()
    {
        StatePanel.SetActive(false);
    }

}
