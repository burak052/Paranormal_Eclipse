using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaraDead : MonoBehaviour
{
    public GameObject muzzle;
    public GameObject Laradead;
    public GameObject Laralab;
    public GameObject Aral;
    public ActiveBlackScreen ABS;
    public Dialogs dia;
    private bool triggered = false;

    public int finalSelect = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(Dead());
            ABS.Black();
        }
    }

    IEnumerator Dead()
    {
        Transform tra = Aral.GetComponent<Transform>();
        dia.EventDia(170);
        ABS.DisablePlayer();
        yield return new WaitForSeconds(1.6f);
        tra.position = new Vector3(1562.45f,51.42f,1505.96f);
        tra.rotation = Quaternion.Euler(0f,25.24f,0f);
        tra.Find("CameraParent").Find("Camera").localRotation = Quaternion.Euler(0f,0f,0f);
        Laralab.GetComponent<Transform>().position = new Vector3(1564.291f,51.454f,1512.486f);
        Laralab.GetComponent<Transform>().rotation = Quaternion.Euler(0f,203f,0f);
        Laradead.GetComponent<Transform>().position = new Vector3(1566.54f,51.45f,1510.73f);
        Laradead.GetComponent<Transform>().rotation = Quaternion.Euler(0f,132.785f,0f);
        Laralab.GetComponent<Transform>().Find("gun").gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.6f);
        dia.EventDia(171,0.5f);
        float t = 0f;
        while (t < 3f)
        {
            t += Time.deltaTime;
            float normalizedT = t / 3f;
            tra.Find("CameraParent").Find("Camera").localPosition = Vector3.Lerp(new Vector3(0f,0f,0f), new Vector3(0f,0f,2f), Mathf.SmoothStep(0f, 1f, normalizedT));
            yield return null;
        }
        muzzle.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        ABS.blackScreen.gameObject.SetActive(true);
        ABS.blackScreen.color = new Color(0, 0, 0, 1f);
        Laralab.GetComponent<Transform>().Find("gun").gameObject.GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(1.6f); //ateşten sonraki siyah ekran
        tra.Find("CameraParent").Find("Camera").localPosition = new Vector3(0f,0f,0f);
        tra.position = new Vector3(1563.84f,51.42f,1511.276f);
        Laralab.GetComponent<Animator>().SetBool("idle",true);
        Laralab.GetComponent<Transform>().Find("gun").gameObject.SetActive(false);
        yield return new WaitForSeconds(4f);

        ABS.DisBlack();
        muzzle.SetActive(false);
        dia.gameObject.GetComponent<Transform>().parent.Find("Selections").gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitUntil(() => finalSelect != 0);       //seçim ekranı beklemesi
        if(finalSelect == 1)
        {

        }
        else if(finalSelect == 2)
        {

        }
        else if(finalSelect == 3)
        {

        }
    }
}
