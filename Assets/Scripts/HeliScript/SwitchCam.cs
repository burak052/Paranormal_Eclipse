using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public GameObject camA;
    public GameObject camB;

    void Start()
    {
        camA.SetActive(true);
        camB.SetActive(false);
    }

    public void SwitchCam()
    {
        camA.SetActive(false);
        camB.SetActive(true);
    }
}
