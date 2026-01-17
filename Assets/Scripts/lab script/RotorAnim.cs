using UnityEngine;
using System.Collections;

public class RotorAnim : MonoBehaviour
{
    public GameObject redButton;
    int count = 1;
    public void CapsuleRotate()
    {
        gameObject.GetComponent<Animator>().SetInteger("Count",count);
        count++;
        if(count == 6)
        {
            redButton.GetComponent<HighlightBlink>().ping = true;
            redButton.GetComponent<Transform>().parent.gameObject.tag = "RedButton";
        }
    }
    public void PlaySound()
    {
        gameObject.GetComponent<Transform>().parent.Find("Cube").gameObject.GetComponent<AudioSource>().Play();
    }
    public void RotorSpin()
    {
        redButton.GetComponent<HighlightBlink>().stopPing();
        gameObject.GetComponent<Transform>().parent.Find("Cube").gameObject.GetComponents<AudioSource>()[1].Play();
        GetComponent<Animator>().SetInteger("Count",7);
    }
}
