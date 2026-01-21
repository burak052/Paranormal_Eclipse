using UnityEngine;
using System.Collections;

public class LaraDoorCrash : MonoBehaviour
{
    public bool stop = false;
    bool first = false;
    bool isPlaying = false;

    void Update()
    {
        if (!stop && !isPlaying) 
        {
            StartCoroutine(PlayDoorAnim());
        }
        if(stop)
        {
            StopAllCoroutines();
            GetComponent<Animator>().SetBool("Open", true);
        }

    }

    IEnumerator PlayDoorAnim()
    {
        isPlaying = true;

        Animator anim = GetComponent<Animator>();
        anim.SetBool("Open", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("Open", false);
        yield return new WaitForSeconds(1.5f);

        isPlaying = false;
    }

}
