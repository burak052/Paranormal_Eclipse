using UnityEngine;
using System.Collections;

public class LaserTrigger : MonoBehaviour
{
    public AudioSource laserSound;
    bool isfinish = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isfinish)
        {
            StartCoroutine(LaserMove());
        }
    }

    IEnumerator LaserMove()
    {
        isfinish = false;

        Transform laser = transform.parent.Find("Laser");
        laser.localPosition = new Vector3(0f, 2.437f, 0f);

        Vector3 start = laser.localPosition;
        Vector3 target = new Vector3(0f, 0.114f, 0f);

        float t = 0f;

        laserSound.volume = 1f;
        laserSound.Play();

        float clipLength = laserSound.clip.length;
        float fadeDuration = 1f;
        float fadeStartTime = clipLength - fadeDuration;

        float soundTimer = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 0.2f;
            laser.localPosition = Vector3.Lerp(start, target, t);

            // ses süresi takibi
            soundTimer += Time.deltaTime;

            // fade-out başlasın
            if (soundTimer >= fadeStartTime)
            {
                float fadeT = (soundTimer - fadeStartTime) / fadeDuration;
                laserSound.volume = Mathf.SmoothStep(1f, 0f, fadeT);
            }

            yield return null;
        }

        laserSound.Stop();
        laserSound.volume = 1f; // bir dahaki kullanım için reset

        isfinish = true;
    }
}
