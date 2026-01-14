using UnityEngine;

public class PlayLabAmbiance : MonoBehaviour
{
    public void PlayAmbiance()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
