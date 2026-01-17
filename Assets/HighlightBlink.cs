using UnityEngine;
using System.Collections;

public class HighlightBlink : MonoBehaviour
{
    public Material material;
    public Material material2;
    Material[] mats;
    bool busy = false;
    public bool ping = true;

    void Update()
    {
        if (!busy && ping)
            StartCoroutine(EmissionPulse());
    }
    IEnumerator EmissionPulse()
    {
        busy = true;
        yield return new WaitForSeconds(1f);
        if(gameObject.tag == "RepairKit")
        {
            mats = GetComponent<Renderer>().materials;
            mats[1] = material2;
            GetComponent<Renderer>().materials = mats;
        }
        else
            GetComponent<Renderer>().material = material2;
        yield return new WaitForSeconds(1f);
        if(gameObject.tag == "RepairKit")
        {
            mats = GetComponent<Renderer>().materials;
            mats[1] = material;
            GetComponent<Renderer>().materials = mats;
        }
        else
            GetComponent<Renderer>().material = material;
        busy = false;
    }
    public void stopPing()
    {
        StopCoroutine(EmissionPulse());
        ping = false;
        if(gameObject.tag == "RepairKit")
        {
            mats = GetComponent<Renderer>().materials;
            mats[1] = material;
            GetComponent<Renderer>().materials = mats;
        }
        else
            GetComponent<Renderer>().material = material;
    }
}
