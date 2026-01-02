using System.Collections;
using UnityEngine;

public class SmokeTrigger : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource smokeAudio;
    float maxVolume = 1f;

    [Header("Timing")]
    float totalAudioDuration = 10f;
    float fadeInDuration = 2f;
    float fadeOutDuration = 2f;
    float particleStopTime = 10f;

    [Header("Colliders To Disable")]
    public BoxCollider colliderA;
    public BoxCollider colliderB;

    ParticleSystem[] particles;
    bool triggered;

    void Awake()
    {
        particles = GetComponentsInChildren<ParticleSystem>(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;
        StartCoroutine(SmokeRoutine());
    }

    IEnumerator SmokeRoutine()
    {
        if (colliderA) colliderA.enabled = false;
        if (colliderB) colliderB.enabled = false;
        // Particle başlat
        foreach (var ps in particles)
            ps.Play();

        // Ses başlat
        smokeAudio.volume = 0f;
        smokeAudio.Play();

        // Fade In (0–2 sn)
        float t = 0f;
        while (t < fadeInDuration)
        {
            t += Time.deltaTime;
            smokeAudio.volume = Mathf.Lerp(0f, maxVolume, t / fadeInDuration);
            yield return null;
        }

        // 2–8 sn bekle
        yield return new WaitForSeconds(particleStopTime - fadeInDuration);

        // Particle durdur
        foreach (var ps in particles)
            ps.Stop();

        // Fade Out (8–10 sn)
        t = 0f;
        float startVolume = smokeAudio.volume;
        while (t < fadeOutDuration)
        {
            t += Time.deltaTime;
            smokeAudio.volume = Mathf.Lerp(startVolume, 0f, t / fadeOutDuration);
            yield return null;
        }

        smokeAudio.Stop();

        // Her şey bitince collider'ları aç
        if (colliderA) colliderA.enabled = true;
        if (colliderB) colliderB.enabled = true;
    }
}
