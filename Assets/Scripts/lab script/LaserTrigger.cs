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
        laserSound.Play();

        while (t < 1f)
        {
            t += Time.deltaTime * 0.2f;
            laser.localPosition = Vector3.Lerp(start, target, t);

            yield return null;
        }

        isfinish = true;
    }
}
