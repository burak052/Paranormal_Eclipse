using UnityEngine;
using System.Collections;

public class RotorAnim : MonoBehaviour
{
    int count = 1;
    public void CapsuleRotate()
    {
        gameObject.GetComponent<Animator>().SetInteger("Count",count);
        count++;
    }
    public void PlaySound()
    {
        gameObject.GetComponent<Transform>().parent.Find("Cube").gameObject.GetComponent<AudioSource>().Play();
    }
    public void RotorSpin()
    {
        gameObject.GetComponent<Transform>().parent.Find("Cube").gameObject.GetComponents<AudioSource>()[1].Play();
        GetComponent<Animator>().SetInteger("Count",7);
    }
}
