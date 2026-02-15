using UnityEngine;

public class OpenGenerator : MonoBehaviour
{
    public GameObject L1;
    public GameObject ElevatorButton;

    public void PowerOn()
    {
        LightController[] lights = FindObjectsOfType<LightController>();
        L1.SetActive(true);
        ElevatorButton.tag = "ElevatorDoorOpen";
        foreach (LightController lc in lights)
        {
            lc.generator = true;
        }
    }
}
