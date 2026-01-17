using UnityEngine;

public class TestStart : MonoBehaviour
{
    public GameObject rotor;
    public void StartTest()
    {
        rotor.GetComponent<RotorAnim>().RotorSpin();
        GetComponent<Transform>().Find("button").gameObject.GetComponent<Animator>().SetTrigger("Start");
        GetComponent<Transform>().Find("button").gameObject.GetComponent<HighlightBlink>().stopPing();
    }
}
