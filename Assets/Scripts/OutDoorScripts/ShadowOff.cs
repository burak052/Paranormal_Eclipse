using UnityEngine;

public class ShadowOff : MonoBehaviour
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
            transform.parent.Find("shadow spawn").gameObject.SetActive(false);
            transform.parent.gameObject.GetComponent<AudioSource>().Play();  
            gameObject.SetActive(false);      }
    }
}
