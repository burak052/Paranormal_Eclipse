using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerEnter : MonoBehaviour
{
    public ShadowDisable shad;
    public ActiveBlackScreen ABS;
    public Dialogs dia;
    public Sprite shadow;
    bool first = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && first)
        {
            shad.DisableShadow();
            StartCoroutine(CamScare());
            first = false;
        }
    }
    IEnumerator CamScare()
    {
        ABS.DisablePlayer();
        dia.gameObject.GetComponent<AudioSource>().Play();
        dia.gameObject.GetComponent<Transform>().parent.Find("BlackScreen").GetComponent<Image>().color = new Color(0f,0f,0f,1f);
        dia.gameObject.GetComponent<Transform>().parent.Find("BlackScreen").gameObject.SetActive(true);
        dia.gameObject.GetComponent<Transform>().parent.Find("BlackScreen").GetComponent<Image>().sprite = shadow;
        yield return new WaitForSeconds(1.5f);
        dia.gameObject.GetComponent<Transform>().parent.Find("BlackScreen").GetComponent<Image>().color = new Color(0f,0f,0f,0f);
        dia.gameObject.GetComponent<Transform>().parent.Find("BlackScreen").GetComponent<Image>().sprite = null;
        dia.gameObject.GetComponent<Transform>().parent.Find("BlackScreen").gameObject.SetActive(false);
        dia.EventDia(35,1.5f); 
        ABS.ActivePlayer();
        transform.parent.gameObject.SetActive(false);
    }
}
