using UnityEngine;
using System.Collections;

public class LaraMovement : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void LaraBeach()
    {
        GetComponent<Animator>().SetBool("sitting", true);
        transform.position = new Vector3(1471.97f,2.13f,1788.94f);
        transform.rotation = Quaternion.Euler(0f,25f,0f);
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
        target = new Vector3(1409.43f,5.21f,1668.57f);
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
        target = new Vector3(1408.92f,5.21f,1667.66f);
        startRot = transform.rotation;
        targetRot = Quaternion.Euler(0f, 251f, 0f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.7f;
            transform.position = Vector3.Lerp(start, target, t);
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }

        start = transform.position;
        target = new Vector3(1405.61f,5.21f,1666.51f);
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