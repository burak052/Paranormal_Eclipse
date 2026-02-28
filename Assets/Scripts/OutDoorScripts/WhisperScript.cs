using UnityEngine;

public class WhisperScript : MonoBehaviour
{
    bool first = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && first)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
            first = false;
        }
    }
}
