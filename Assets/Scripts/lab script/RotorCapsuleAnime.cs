using UnityEngine;

public class RotorCapsuleAnime : MonoBehaviour
{
    public void RotorAnim()
    {
        transform.parent.gameObject.GetComponent<AudioSource>().Play();
        GetComponent<MeshRenderer>().enabled = true;
        transform.Find("gem").gameObject.SetActive(true);
        GetComponent<Animator>().SetBool("Start", true);
        tag = "Untagged";
        transform.parent.parent.gameObject.GetComponent<RotorAnim>().CapsuleRotate();
    }
}
