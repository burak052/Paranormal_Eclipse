using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeachCinematic : MonoBehaviour
{
    public GameObject Lara;
    public GameObject Laradead;
    public GameObject Laralab;
    public GameObject Aral;
    public ActiveBlackScreen ABS;
    public Animator door;
    public GameObject pastAral;
    public GameObject night;
    public GameObject nightlight;
    public GameObject day;
    public GameObject daylight;

    private bool triggered = false;

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
        yield return new WaitForSeconds(5f);//bu süre lara ile konuşma süresi
        ABS.Black();
        yield return new WaitForSeconds(1.6f);

        Aral.GetComponent<Transform>().position = new Vector3(1448.65f,4.26f,1788.04f);
        Aral.GetComponent<Transform>().rotation = Quaternion.Euler(0f,77f,0f);
        Lara.GetComponent<LaraMovement>().LaraBeach();
        pastAral.GetComponent<Transform>().position = new Vector3(1472.74f,1.94f,1790.86f);
        pastAral.GetComponent<Transform>().rotation = Quaternion.Euler(0f,-163.602f,0f);

        yield return new WaitForSeconds(6f);
        ABS.GlassBroke();
        yield return new WaitForSeconds(3f);
        Aral.GetComponent<Transform>().position = new Vector3(1437.80f,4.35f,1668.34f);
        Aral.GetComponent<Transform>().rotation = Quaternion.Euler(0f,-93.866f,0f);
        yield return new WaitForSeconds(4f);
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
        yield return new WaitForSeconds(5f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.4f;
            Aral.GetComponent<Transform>().rotation = Quaternion.Slerp(Aral.GetComponent<Transform>().rotation, Quaternion.Euler(27.72f,56.964f,0f), t);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        ABS.GlassBroke();
        yield return new WaitForSeconds(2.5f);
        Aral.GetComponent<Transform>().rotation = Quaternion.Euler(0f,56.964f,0f);
        pastAral.GetComponent<AudioSource>().Stop();
        night.SetActive(false);
        nightlight.SetActive(false);
        day.SetActive(true);
        daylight.SetActive(true);
        Aral.GetComponent<Transform>().position = new Vector3(1466.43f,45.11f,1474.10f);



        yield return new WaitForSeconds(6f);
        ABS.ActivePlayer();
    }
}
