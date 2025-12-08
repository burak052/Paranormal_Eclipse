using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioSource openAudioSource;
    public AudioSource closeAudioSource;

    public void PlayOpenSound()
    {
        openAudioSource.Play();
    }

    public void PlayCloseSound()
    {
        closeAudioSource.Play();
    }
}
