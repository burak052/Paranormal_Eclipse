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
        dia.dialog.text = dia.dias[24];
        yield return new WaitForSeconds(7f);
        dia.dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dia.dialog.text = dia.dias[26];
        yield return new WaitForSeconds(2.5f);
        dia.dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dia.dialog.text = dia.dias[27];
        yield return new WaitForSeconds(6f);
        dia.dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dia.dialog.text = dia.dias[28];
        yield return new WaitForSeconds(3f);
        dia.dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dia.dialog.text = dia.dias[29];
        yield return new WaitForSeconds(6f);
        dia.dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dia.dialog.text = dia.dias[30];
        yield return new WaitForSeconds(3f);
        dia.dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dia.dialog.text = dia.dias[31];
        yield return new WaitForSeconds(2f);
        dia.dialog.text = "";
        missions.DisMis(++(missions.missionCount));
        bed.tag = "bed";
        bed1.tag = "bed";
    }
}
