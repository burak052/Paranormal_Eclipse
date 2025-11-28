using UnityEngine;

public class HeliSoundActivator : MonoBehaviour
{
    public GameObject heliSoundObject;

    public void ActivateHeliSound()
    {
        AudioSource audio = heliSoundObject.GetComponent<AudioSource>();
        if (audio != null)
            audio.enabled = true;
    }
}
