using UnityEngine;
using System.Collections;

public class LabMovement : MonoBehaviour
{
    public void XRayCinematic()
    {
        StartCoroutine(StartCinematic());
    }
    IEnumerator StartCinematic()
    {
        Vector3 start = transform.position;
        Vector3 target = new Vector3(1376.07f,4.71f,1564.65f);
        Quaternion startRot = transform.rotation;
        Quaternion targetRot = Quaternion.Euler(0f, -203.87f, 0f);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 1.5f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        t = 0f; 

        while (t < 1f)
        {
            t += Time.deltaTime * 0.7f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        t = 0f;

        startRot = transform.rotation;
        targetRot = Quaternion.Euler(0f, -135.42f, 0f);
        while (t < 1f)
        {
            t += Time.deltaTime * 1.2f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }

        start = transform.position;
        target = new Vector3(1374.81f,4.71f,1563.33f);
        t = 0f;

        transform.Find("aral_lab").gameObject.GetComponent<Animator>().SetBool("isWalking", true);
        while (t < 1f)
        {
            t += Time.deltaTime * 0.7f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        
        start = transform.position;
        target = new Vector3(1374.33f,4.90f,1562.84f);
        t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 0.7f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        transform.Find("aral_lab").gameObject.GetComponent<Animator>().SetBool("isWalking", false);
        GetComponent<EasyPeasyFirstPersonController.FirstPersonController>().enabled = true;
    }
}
