using UnityEngine;
using System.Collections;

public class RunShadow : MonoBehaviour
{
    private bool triggered = false;
    public Dialogs dia;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            Transform shadow = transform.Find("shadow");
            if (shadow != null)
            {
                triggered = true;
                StartCoroutine(ShadowRoutine(shadow.gameObject));
            }
        }
    }

    IEnumerator ShadowRoutine(GameObject shadow)
    {
        dia.EventDia(121,1f);
        GetComponent<AudioSource>().Play();
        shadow.SetActive(true);
        shadow.GetComponent<Animator>().SetTrigger("start");
        shadow.GetComponent<Transform>().Find("MaleBase").gameObject.GetComponent<Animator>().SetBool("start",true);
        yield return new WaitForSeconds(2f);
        shadow.SetActive(false);
        shadow.GetComponent<Transform>().Find("MaleBase").gameObject.GetComponent<Animator>().SetBool("start",false);
    }
}