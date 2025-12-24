using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShadowDisable : MonoBehaviour
{
    public GameObject Shadow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisableShadow();
    }

    public void EnableShadow()
    {
        Shadow.SetActive(true);
    }
    public void DisableShadow()
    {
        Shadow.SetActive(false);
    }
}
