using UnityEngine;
using System.Collections;

public class LaraMovement : MonoBehaviour
{
    public void LaraBeach()
    {
        GetComponent<Animator>().SetBool("sitting", true);
        transform.position = new Vector3(1471.97f,2.13f,1788.94f);
        transform.rotation = Quaternion.Euler(0f,25f,0f);
    }
    public void LaraLocker()
    {
        transform.position = new Vector3(1381.16f,4.71f,1564.52f);
        transform.rotation = Quaternion.Euler(0f,-34.96f,0f);
    }

    public void XRayCinematic()
    {
        StartCoroutine(StartCinematic());
    }
    IEnumerator StartCinematic()
    {
        float t = 0f;
        Vector3 start = transform.position;
        Vector3 target = new Vector3(1376.13f,4.72f,1562.01f);
        yield return new WaitForSeconds(3f);
        GetComponent<Animator>().SetBool("walk", true);
        while (t < 1f)
        {
            t += Time.deltaTime * 0.7f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        start = transform.position;
        target = new Vector3(1375.66f,4.92f,1561.55f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1.2f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        GetComponent<Animator>().SetBool("walk", false);
    }

    public void LaraXray()
    {
        StartCoroutine(MoveXray());
    }
    IEnumerator MoveXray()
    {
        Vector3 start = transform.position;
        Vector3 target = new Vector3(1377.34f,4.71f, 1563.40f);
        Quaternion startRot = transform.rotation;
        Quaternion targetRot = Quaternion.Euler(0f, -134.208f, 0f);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 2f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
        GetComponent<Animator>().SetBool("walk", true);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.3f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        GetComponent<Animator>().SetBool("walk", false);
    }

    public void LaraShelter()
    {
        GetComponent<Animator>().SetBool("walk", true);
        transform.position = new Vector3(1417.83704f, 4.01999998f, 1670.13098f);
        transform.rotation = Quaternion.Euler(0f,262f,0f);
        StartCoroutine(MoveRoutine());
    }
    IEnumerator MoveRoutine()
    {
        Vector3 start = transform.position;
        Vector3 target = new Vector3(1414.58f, 4.02f, 1669.75f);

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 0.5f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        
        start = transform.position;
        target = new Vector3(1413.78f,4.79f,1669.68f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        
        start = transform.position;
        target = new Vector3(1411.51f,5.21f,1669.57f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.5f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }

        start = transform.position;
        target = new Vector3(1409.43f,5.15f,1668.57f);
        Quaternion startRot = transform.rotation;
        Quaternion targetRot = Quaternion.Euler(0f, 209f, 0f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.7f;
            transform.position = Vector3.Lerp(start, target, t);
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }

        start = transform.position;
        target = new Vector3(1408.92f,5.15f,1667.66f);
        startRot = transform.rotation;
        targetRot = Quaternion.Euler(0f, 251f, 0f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1.2f;
            transform.position = Vector3.Lerp(start, target, t);
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }

        start = transform.position;
        target = new Vector3(1405.61f,5.15f,1666.51f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.6f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }

        GetComponent<Animator>().SetBool("walk", false);
        startRot = transform.rotation;
        targetRot = Quaternion.Euler(0f, 182f, 0f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 2f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
    }
}
//laranın başlangıç konumu
//Vector3(1566.6156,51.4751549,1510.49512)
//Quaternion(0,0.904853523,0,0.425723076)