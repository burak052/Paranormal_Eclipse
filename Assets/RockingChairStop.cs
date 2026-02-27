using UnityEngine;
using System.Collections;

public class RockingChairStop : MonoBehaviour
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
        yield return new WaitForSeconds(1f);
        transform.parent.parent.Find("RockingChairFBX").gameObject.GetComponent<Animator>().speed = 0f;
        transform.parent.parent.Find("RockingChairFBX").gameObject.GetComponent<AudioSource>().Stop();
        transform.parent.gameObject.SetActive(false);
    }
}
