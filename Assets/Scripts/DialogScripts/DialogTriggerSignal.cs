using UnityEngine;
using System.Collections;

public class DialogTriggerSignal : MonoBehaviour
{
    public Dialogs dia;
    public Missions missions;
    public GameObject bed;
    public GameObject bed1;
    bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            StartCoroutine(BeforeSleep());
            triggered = true;
        }
    }
    IEnumerator BeforeSleep()
    {
        yield return StartCoroutine(dia.EventDialog(24));
        dia.dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(dia.EventDialog(26));
        dia.dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(dia.EventDialog(27));
        dia.dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(dia.EventDialog(28));
        dia.dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(dia.EventDialog(29));
        dia.dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(dia.EventDialog(30));
        dia.dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(dia.EventDialog(31));
        dia.dialog.text = "";
        missions.DisMis(5);
        bed.tag = "bed";
        bed1.tag = "bed";
    }
}
