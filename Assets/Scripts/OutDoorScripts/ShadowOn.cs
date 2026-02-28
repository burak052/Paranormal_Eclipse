using UnityEngine;

public class ShadowOn : MonoBehaviour
{
    private GameObject maleBase;

    private void Start()
    {
        // Parent içindeki MaleBase'i bir kez bulup referans alıyoruz
        maleBase = transform.parent.Find("MaleBase").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            maleBase.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            maleBase.SetActive(true);
        }
    }
}