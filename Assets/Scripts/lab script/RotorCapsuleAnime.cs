using UnityEngine;

public class RotorCapsuleAnime : MonoBehaviour
{
    public void RotorAnim()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        transform.Find("gem").gameObject.SetActive(true);
        gameObject.GetComponent<Animator>().SetBool("Start", true);
        gameObject.tag = "Untagged";
        transform.parent.parent.gameObject.GetComponent<RotorAnim>().CapsuleRotate();
    }
}
