using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class SmokeTrigger : MonoBehaviour
{
    public VisualEffect smokeVFX;
    bool hasTriggered = false;

    public AudioSource steamSound;
    public float fadeInDuration = 2f;
    public float playDuration = 8f;
    public float fadeOutDuration = 2f;
    public GameObject collider1;
    public GameObject collider2;

    void Start()
    {
        smokeVFX.SetFloat("Alpha", 1f); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;
        if (!other.CompareTag("Player")) return;

        hasTriggered = true;
        GetComponent<Collider>().enabled = false;

        smokeVFX.SendEvent("OnPlay");
        smokeVFX.Play();

        StartCoroutine(FadeAndStop());
    }

    IEnumerator FadeAndStop()
    {
        collider1.SetActive(false);
        collider2.SetActive(false);
        steamSound.volume = 0f;
        steamSound.Play();

        // Fade In
        float t = 0f;
        while (t < fadeInDuration)
        {
            t += Time.deltaTime;
            steamSound.volume = Mathf.Lerp(0f, 1f, t / fadeInDuration);
            yield return null;
        }
        steamSound.volume = 1f;

        yield return new WaitForSeconds(8f);

        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / 1f);
            smokeVFX.SetFloat("Alpha", alpha); 
            steamSound.volume = Mathf.Lerp(1f, 0.2f, t / 1f);
            yield return null;
        }

        smokeVFX.SendEvent("OnStop"); 
        yield return new WaitForSeconds(2f);
        steamSound.Stop();
        collider1.SetActive(true);
        collider2.SetActive(true);
    }
}
