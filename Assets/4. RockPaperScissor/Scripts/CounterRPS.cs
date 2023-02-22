using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CounterRPS : MonoBehaviour
{
    public TMP_Text text;
    public int counter = 3;
    private Animator anim;
    private bool end;
    public UIManagerRPS manager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartScene();

    }

    public void StartScene()
    {
        end = true;

        text.text = counter.ToString();
        StartCoroutine(Number(counter));
    }

    IEnumerator Number(int counterInstance)
    {
        
        while (end)
        {
            if (counterInstance <= 0)
            {
                end = false;
                manager.ChangeScondScene();
                break;
            }
                
            anim.SetTrigger("StartAnim");
            yield return new WaitForSeconds(1f);
            counterInstance--;
            text.text = counterInstance.ToString();
        }
    }

}
