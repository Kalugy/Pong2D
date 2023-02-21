
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterAnimation : MonoBehaviour
{
    private List<Animator> animators;

    // Start is called before the first frame update
    void Start()
    {
        animators = new List<Animator>(GetComponentsInChildren<Animator>());

        StartCoroutine(Delay());

    }

    IEnumerator Delay()
    {
        while (true)
        {
            foreach(Animator a in animators)
            {
                a.SetTrigger("DoAnimation");
                yield return new WaitForSeconds(.1f);
            }
            yield return new WaitForSeconds(.5f);
        }
        
    }
    
}
