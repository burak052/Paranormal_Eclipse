using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public GameObject camA;
    public GameObject camB;

    public void SwitchCam()
    {
        camA.SetActive(false);
        camB.SetActive(true);
    }
}
