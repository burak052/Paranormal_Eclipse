using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShadowDisable : MonoBehaviour
{
    public Image Shadow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Shadow.enabled = false;
    }

    public void EnableShadow()
    {
        Shadow.enabled = true;
    }
    public void DisableShadow()
    {
        Shadow.enabled = false;
    }
}
