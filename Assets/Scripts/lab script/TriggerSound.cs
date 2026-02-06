using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public Dialogs dia;
    bool isBroken = false;

    void OnTriggerEnter(Collider other)
    {
        if (isBroken) return;
        if (!other.CompareTag("Player")) return;

        isBroken = true;

        GetComponent<AudioSource>().Play();
        dia.RunSoundDia();
    }
}
