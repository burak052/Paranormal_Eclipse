using UnityEngine;
using System.Collections;

public class LookLabLara : MonoBehaviour
{
    public LaraMovement Lara;
    private bool hasTriggered = false;
    public Dialogs dia;
    public ActiveBlackScreen ABS;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            dia.LabCoat(ABS,Lara);
        }
    }
}
