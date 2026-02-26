using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeachCinematic : MonoBehaviour
{
    public GameObject Lara;
    public GameObject Laradead;
    public GameObject Laralab;
    public GameObject Aral;
    public Transform lantern;
    public ActiveBlackScreen ABS;
    public Animator door;
    public Dialogs dia;
    public GameObject pastAral;
    public GameObject night;
    public GameObject nightlight;
    public GameObject day;
    public GameObject daylight;
    public AudioSource amb;
    public AudioClip ambClip;
    public BoxCollider LD;
    public Missions mis;

    private bool triggered = false;

    void Start()
    {
        Laralab.SetActive(false);
        Laradead.SetActive(false);
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(Beach());
            ABS.Black();
        }
    }

    IEnumerator Beach()
    {
        ABS.DisablePlayer();
        yield return new WaitForSeconds(1.6f);
        Lara.GetComponent<Transform>().rotation = Quaternion.Euler(0f,201.4f,0f);
        Lara.GetComponent<Animator>().SetBool("idle",true);
        Aral.GetComponent<Transform>().position = new Vector3(1477.92f,2.10f,1788.94f);
        Aral.GetComponent<Transform>().rotation = Quaternion.Euler(18f,20.635f,0f);
        Aral.GetComponent<Transform>().Find("CameraParent").Find("Camera").localRotation = Quaternion.Euler(0f,0f,0f);
        yield return new WaitForSeconds(1.6f);
        yield return StartCoroutine(dia.BoatDialog());
        ABS.Black();
        yield return new WaitForSeconds(1.6f);

        lantern.localPosition = new Vector3(-146.87f,36.65f,-50.22f);
        lantern.localRotation = Quaternion.Euler(3.179f,0.311f,-1.402f);
        Aral.GetComponent<Transform>().position = new Vector3(1448.65f,4.26f,1788.04f);
        Aral.GetComponent<Transform>().rotation = Quaternion.Euler(6.32f,83.46f,0f);
        Lara.GetComponent<LaraMovement>().LaraBeach();
        pastAral.GetComponent<Transform>().position = new Vector3(1472.74f,1.94f,1790.86f);
        pastAral.GetComponent<Transform>().rotation = Quaternion.Euler(0f,-163.602f,0f);
        yield return new WaitForSeconds(3f);
        dia.EventDia(161);

        yield return new WaitForSeconds(3f);
        ABS.GlassBroke();
        
        float ti = 0f;
        while (ti < 7f)
        {
            ti += Time.deltaTime;
            float normalizedT = ti / 7f;
            Aral.GetComponent<Transform>().Find("CameraParent/Camera").localPosition = Vector3.Lerp(new Vector3(0f,0f,0f), new Vector3(0f,0f,20f), Mathf.SmoothStep(0f, 1f, normalizedT));
            yield return null;
        }
        dia.EventDia(162);
        Aral.GetComponent<Transform>().position = new Vector3(1437.80f,4.35f,1668.34f);
        Aral.GetComponent<Transform>().rotation = Quaternion.Euler(0f,-93.866f,0f);
        Aral.GetComponent<Transform>().Find("CameraParent/Camera").localPosition = new Vector3(0f,0f,0f);
        yield return new WaitForSeconds(2f);
        Aral.GetComponent<Transform>().Find("aral.v1 (1)").gameObject.GetComponent<Animator>().SetBool("isWalking",true);
        pastAral.GetComponent<Transform>().position = new Vector3(1410.85f,5.28f,1669.72f);
        pastAral.GetComponent<Transform>().rotation = Quaternion.Euler(0f,-267.38f,0f);
        
        float duration = 8f;
        float t = 0f;
        Vector3 startPos = Aral.GetComponent<Transform>().position;
        Vector3 target = new Vector3(1416.426f,3.984f,1666.909f);
        while (t < duration)
        {
            t += Time.deltaTime;
            float normalizedT = t / duration;

            Aral.GetComponent<Transform>().position = Vector3.Lerp(startPos, target, Mathf.SmoothStep(0f, 1f, normalizedT));
            yield return null;
        }
        Aral.GetComponent<Transform>().Find("aral.v1 (1)").gameObject.GetComponent<Animator>().SetBool("isWalking",false);
        pastAral.GetComponent<AudioSource>().Play();
        door.SetBool("justopen",true);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.8f;
            Aral.GetComponent<Transform>().rotation = Quaternion.Slerp(Aral.GetComponent<Transform>().rotation, Quaternion.Euler(0f,-61.284f,0f), t);
            yield return null;
        }
        yield return StartCoroutine(dia.EventDialog(169));
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(dia.EventDialog(163));
        yield return new WaitForSeconds(1f);
        dia.EventDia(164);
        t = 0f;
        ABS.GlassBroke(16f);
        while (t < 1f)
        {
            t += Time.deltaTime * 0.4f;
            Aral.GetComponent<Transform>().rotation = Quaternion.Slerp(Aral.GetComponent<Transform>().rotation, Quaternion.Euler(27.72f,56.964f,0f), t);
            yield return null;
        }
        yield return StartCoroutine(dia.EventDialog(165,5f));
        yield return new WaitForSeconds(1f);
        Aral.GetComponent<Transform>().rotation = Quaternion.Euler(0f,56.964f,0f);
        pastAral.GetComponent<AudioSource>().Stop();
        night.SetActive(false);
        nightlight.SetActive(false);
        day.SetActive(true);
        daylight.SetActive(true);
        Aral.GetComponent<Transform>().position = new Vector3(1466.43f,45.11f,1474.10f);
        Laralab.SetActive(true);
        Laradead.SetActive(true);
        Lara.SetActive(false);
        pastAral.SetActive(false);

        yield return new WaitForSeconds(1f);    //siyah ekran konuşması
        yield return StartCoroutine(dia.EventDialog(166));
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(dia.EventDialog(167));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(dia.EventDialog(168));

        ABS.ActivePlayer();
        amb.clip = ambClip;
        amb.Play();
        Aral.GetComponent<AudioSource>().Stop();
        yield return StartCoroutine(dia.EventDialog(241,2f));
        mis.startdelay = 0f;
        mis.StartMis(18);
        LD.enabled = true;

    }
}
