using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour
{
    public Dialogs dia;
    Light lightComp;
    AudioSource audioSource;
    Coroutine blinkRoutine;
    bool isBroken = false;

    void Start()
    {
        lightComp = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();

        blinkRoutine = StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            lightComp.enabled = !lightComp.enabled;
            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isBroken) return;
        if (!other.CompareTag("Player")) return;

        isBroken = true;

        // Blink'i durdur
        if (blinkRoutine != null)
            StopCoroutine(blinkRoutine);

        // Işığı kesin kapat
        lightComp.enabled = false;

        // Ampül patlama sesi
        if (audioSource != null)
        {
            audioSource.Play();
            dia.EventDia(3f,dia.dias[118],3f);
        }
    }
}
