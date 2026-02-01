using UnityEngine;

public class RadioTowerDialogTrigger : MonoBehaviour
{
    public Dialogs dia;
    public Raycast ray;
    bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered && ray.haveRepairKit)
        {
            dia.EventDia(3f, dia.dias[25]);
            triggered = true;
        }
    }
}
