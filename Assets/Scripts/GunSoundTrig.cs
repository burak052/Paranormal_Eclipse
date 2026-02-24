using UnityEngine;

public class GunSoundTrig : MonoBehaviour
{
    public Dialogs dia;
    public GameObject gun;
    bool first = false;
    void OnTriggerEnter(Collider other)
    {
        if (first) return;
        if (!other.CompareTag("Player")) return;

        gun.SetActive(true);
        first = true;
        dia.EventDia(16,1.5f);
    }
}
