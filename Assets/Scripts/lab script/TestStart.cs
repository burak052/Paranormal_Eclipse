using UnityEngine;

public class TestStart : MonoBehaviour
{
    public GameObject rotor;
    public void StartTest()
    {
        rotor.GetComponent<RotorAnim>().RotorSpin();
    }
}
