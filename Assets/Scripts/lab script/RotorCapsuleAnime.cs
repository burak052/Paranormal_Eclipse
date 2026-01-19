using UnityEngine;
using System.Collections;

public class RotorCapsuleAnime : MonoBehaviour
{
    public void RotorAnim()
    {
        transform.parent.gameObject.GetComponent<AudioSource>().Play();
        GetComponent<MeshRenderer>().enabled = true;
        transform.Find("gem").gameObject.SetActive(true);
        GetComponent<Animator>().SetBool("Start", true);
        tag = "Untagged";
        StartCoroutine(del());
    }
    IEnumerator del()
    {
        yield return new WaitForSeconds(2f);
        transform.parent.parent.gameObject.GetComponent<RotorAnim>().CapsuleRotate();
    }
}
