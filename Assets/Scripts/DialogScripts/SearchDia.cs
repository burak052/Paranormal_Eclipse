using UnityEngine;

public class SearchDia : MonoBehaviour
{
    private bool hasTriggered = false;
    public Dialogs dia;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            dia.SeaDia();
        }
    }
}
