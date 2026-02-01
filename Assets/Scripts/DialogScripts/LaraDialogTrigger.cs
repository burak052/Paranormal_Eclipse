using UnityEngine;
using System.Collections;

public class LaraDialogTrigger : MonoBehaviour
{
    public Dialogs dia;
    bool triggered = false;
    Coroutine dialogCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered && dia.Laradia)
        {
            dialogCoroutine = StartCoroutine(DialogDelay());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !triggered && dia.Laradia)
        {
            if (dialogCoroutine != null)
            {
                StopCoroutine(dialogCoroutine);
                dialogCoroutine = null;
            }
        }
    }

    IEnumerator DialogDelay()
    {
        yield return new WaitForSeconds(10f);
        dia.dialog.text = dia.dias[5];
        yield return new WaitForSeconds(3f);
        dia.dialog.text = "";
        triggered = true; 
    }
}

