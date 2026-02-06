using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SecurityCamscare : MonoBehaviour
{
    public Image glitch;
    public Sprite glitch1;
    public Sprite glitch2;
    public Sprite glitch3;
    public Sprite glitch4;
    public Dialogs dia;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed) return;
        if (!other.CompareTag("Player")) return;

        hasPlayed = true;
        StartCoroutine(DelayCamscare());
    }

    IEnumerator DelayCamscare()
    {
        yield return new WaitForSeconds(2f);

        glitch.gameObject.SetActive(true);
        GetComponent<AudioSource>().Play();

        glitch.sprite = glitch1;
        yield return new WaitForSeconds(0.2f);

        glitch.sprite = glitch2;
        yield return new WaitForSeconds(0.2f);

        glitch.sprite = glitch3;
        transform.Find("Image (11)").gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);

        glitch.sprite = glitch4;

        glitch.gameObject.SetActive(false);
        dia.EventDia(2.5f,dia.dias[122]);
    }
}
