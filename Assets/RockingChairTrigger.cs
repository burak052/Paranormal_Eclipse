using UnityEngine;
using System.Collections;

public class RockingChairTrigger : MonoBehaviour
{
    bool first = false;
    void OnTriggerEnter(Collider other)
    {
        if (first) return;
        if (!other.CompareTag("Player")) return;

        first = true;
        StartCoroutine(d());
    }
    IEnumerator d()
    {
        yield return new WaitForSeconds(5f);
        transform.parent.Find("RockingChairFBX").gameObject.GetComponent<Animator>().SetBool("rot",true);
        yield return new WaitForSeconds(4f);
        transform.Find("Cube").gameObject.SetActive(true);
    }
}
