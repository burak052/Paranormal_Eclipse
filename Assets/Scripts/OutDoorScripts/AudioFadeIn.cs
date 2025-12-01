using UnityEngine;
using System.Collections;

public class AudioFadeIn : MonoBehaviour
{
    public AudioSource audioSource;
    public float startVolume = 0f;
    public float targetVolume = 1f;
    public float fadeDuration = 3f;

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.volume = startVolume;
            audioSource.Play();
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVolume;
    }
}
