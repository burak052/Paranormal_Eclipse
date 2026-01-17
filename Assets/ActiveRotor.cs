using UnityEngine;

public class ActiveRotor : MonoBehaviour
{
    public GameObject G1;
    public GameObject G2;

    public void RotorActive()
    {
        G1.SetActive(true);
        G2.SetActive(true);
    }
}
