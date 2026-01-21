using UnityEngine;

public class StopLaraDoor : MonoBehaviour
{
    public LaraDoorCrash LDC;
    private void OnTriggerEnter(Collider other)
    {
        LDC.stop = true;
        gameObject.SetActive(false);
    }
}
