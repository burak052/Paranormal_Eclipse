using UnityEngine;

public class FlameThrowerTrigger : MonoBehaviour
{
    public Dialogs dia;
    bool first = false;
    void OnTriggerEnter(Collider other)
    {
        if (first) return;
        if (!other.CompareTag("Player")) return;

        first = true;
        dia.EventDia(117);
    }
}
