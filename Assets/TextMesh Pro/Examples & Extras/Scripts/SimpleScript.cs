using UnityEngine;

public class HeliActivator : MonoBehaviour
{
    public GameObject heli;

    public void ActivateHeli()
    {
        heli.SetActive(true);
    }
}
