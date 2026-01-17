using UnityEngine;

public class repairtool : MonoBehaviour
{
    void Start()
    {
        gameObject.tag = "Untagged";
    }
    public void ChangeTag()
    {
        gameObject.tag = "RepairKit";
        GetComponent<HighlightBlink>().ping = true;
    }
    public void Glow()
    {
        gameObject.tag = "RepairKit";
    }
}
