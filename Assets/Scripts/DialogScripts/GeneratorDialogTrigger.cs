using UnityEngine;

public class GeneratorDialogTrigger : MonoBehaviour
{
    public Dialogs dia;
    bool first = false;
    void OnTriggerEnter(Collider other)
    {
        if (first) return;
        if (!other.CompareTag("Player")) return;

        first = true;
        dia.EventDia(1.5f,dia.dias[123]);
    }
}
