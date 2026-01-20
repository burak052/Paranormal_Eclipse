using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighlightBlink : MonoBehaviour
{
    public Material material;
    public Material material2;
    Material[] mats;
    bool busy = false;
    public bool ping = true;
    public bool ispaper = false;

    void Update()
    {
        if (!busy && ping && !ispaper)
            StartCoroutine(EmissionPulse());
        if(!busy && ping && ispaper)
            StartCoroutine(EmissionPulsePaper());
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
    IEnumerator EmissionPulsePaper()
    {
        busy = true;
        yield return new WaitForSeconds(1f);
        GetComponent<Image>().material = material;
        yield return new WaitForSeconds(1f);
        GetComponent<Image>().material = material2;
        busy = false;
    }
    public void stopPing()
    {
        StopAllCoroutines();
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
