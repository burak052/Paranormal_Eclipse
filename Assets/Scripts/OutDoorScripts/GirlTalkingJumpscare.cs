
using UnityEngine;

public class GirlTalkingJumpscare : MonoBehaviour
{
    public AudioSource scareAudio;
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed) return;

        if (other.CompareTag("Player"))
        {
            hasPlayed = true;

            scareAudio.Play();

            Destroy(gameObject);
        }
    }
}
