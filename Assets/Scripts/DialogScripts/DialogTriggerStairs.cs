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
        dia.dialog.text = dia.dias[15];
        StartCoroutine(cor1());
    }
    IEnumerator cor1()
    {
        yield return new WaitForSeconds(4f);
        dia.dialog.text = "";
    }
}
