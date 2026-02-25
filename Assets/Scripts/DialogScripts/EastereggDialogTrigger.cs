using UnityEngine;
using System.Collections;

public class EastereggDialogTrigger : MonoBehaviour
{
    public Dialogs dia;
    bool first = false;
    void OnTriggerEnter(Collider other)
    {
        if (first) return;
        if (!other.CompareTag("Player")) return;

        first = true;
        dia.EventDia(133);
        StartCoroutine(DelayStopSound());
    }
    IEnumerator DelayStopSound()
    {
        yield return new WaitForSeconds(10f);
        AudioSource source = GetComponent<AudioSource>();
        float startVolume = source.volume;
        float time = 0f;
        float duration = 10f;

        while (time < duration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, 0f, time / duration);
            yield return null;
        }

        source.volume = 0f;
        source.Stop();
    }
}
