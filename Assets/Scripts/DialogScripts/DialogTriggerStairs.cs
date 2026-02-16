using UnityEngine;
using System.Collections;

public class DialogTriggerStairs : MonoBehaviour
{
    public Dialogs dia;
    bool first = false;
    void OnTriggerEnter(Collider other)
    {
        if (first) return;
        if (!other.CompareTag("Player")) return;

        first = true;
        StartCoroutine(cor1());
    }
    IEnumerator cor1()
    {
        yield return StartCoroutine(dia.EventDialog(15));
        dia.dialog.text = "";
    }
}
