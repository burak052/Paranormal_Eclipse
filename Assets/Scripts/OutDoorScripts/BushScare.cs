using UnityEngine;
using System.Collections;

public class BushScare : MonoBehaviour
{
    public Dialogs dia;
    public AudioSource jumpScareAudio;
    public bool playOnce = true;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (playOnce && hasPlayed)
            return;

        if (jumpScareAudio != null)
        {
            jumpScareAudio.Play();
            hasPlayed = true;
            StartCoroutine(cor1());
        }
        else
        {
            Debug.LogWarning("JumpScare AudioSource atanmad�!");
        }
    }
    IEnumerator cor1()
    {
        yield return new WaitForSeconds(1f);
        dia.dialog.text = dia.dias[16];
        yield return new WaitForSeconds(3f);
        dia.dialog.text = "";
        yield return new WaitForSeconds(2f);
        dia.dialog.text = dia.dias[17];
        yield return new WaitForSeconds(3f);
        dia.dialog.text = "";
    }

}
