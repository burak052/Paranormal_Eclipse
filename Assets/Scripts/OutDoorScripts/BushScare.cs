using UnityEngine;

public class BushScare : MonoBehaviour
{

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
        }
        else
        {
            Debug.LogWarning("JumpScare AudioSource atanmadý!");
        }
    }

}
