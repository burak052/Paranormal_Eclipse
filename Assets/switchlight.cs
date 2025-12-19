using UnityEngine;

public class switchlight : MonoBehaviour
{
    private Light flashLight;
    public Raycast spotraycast;

    void Start()
    {
        flashLight = GetComponent<Light>();

        // Sahne baþladýðýnda kapalý
        flashLight.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && spotraycast.haveheadlight)
        {
            flashLight.enabled = !flashLight.enabled;
        }
    }
}