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
    private bool triggered = false;

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
        ABS.DisablePlayer();
        yield return new WaitForSeconds(1.6f);
        Aral.GetComponent<Transform>().position = new Vector3(1559f,51.42f,1504.56f);
        Aral.GetComponent<Transform>().rotation = Quaternion.Euler(0f,25.24f,0f);
        Aral.GetComponent<Transform>().Find("CameraParent").Find("Camera").localRotation = Quaternion.Euler(0f,0f,0f);
        Laralab.GetComponent<Transform>().position = new Vector3(1563.59f,51.45f,1512.82f);
        Laralab.GetComponent<Transform>().rotation = Quaternion.Euler(0f,203f,0f);
        Laradead.GetComponent<Transform>().position = new Vector3(1566.54f,51.45f,1510.73f);
        Laradead.GetComponent<Transform>().rotation = Quaternion.Euler(0f,132.785f,0f);
        yield return new WaitForSeconds(1.6f);
        yield return new WaitForSeconds(3f);
        muzzle.SetActive(true);
        yield return new WaitForSeconds(1f);


        // t = 0f;
        // while (t < 1f)
        // {
        //     t += Time.deltaTime * 0.8f;
        //     Aral.GetComponent<Transform>().rotation = Quaternion.Slerp(Aral.GetComponent<Transform>().rotation, Quaternion.Euler(0f,-61.284f,0f), t);
        //     yield return null;
        // }
        ABS.GlassBroke();
        yield return new WaitForSeconds(4f);
        ABS.ActivePlayer();
        muzzle.SetActive(false);
    }
}
