using UnityEngine;

public class HeliSoundActivator : MonoBehaviour
{
    public GameObject heliSoundObject;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ActivateHeliSound()
    {
        AudioSource audio = heliSoundObject.GetComponent<AudioSource>();
        if (audio != null)
            audio.enabled = true;
    }
}
