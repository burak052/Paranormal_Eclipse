using UnityEngine;
using System.Collections;

public class LaraMovement : MonoBehaviour
{
    public bool elevator = true;
    public void LaraBeach()
    {
        GetComponent<Animator>().SetBool("sitting", true);
        transform.position = new Vector3(1471.97f,2.13f,1788.94f);
        transform.rotation = Quaternion.Euler(0f,25f,0f);
    }
    public void LaraLocker()
    {
        transform.position = new Vector3(1381.16f,4.736f,1564.52f);
        transform.rotation = Quaternion.Euler(0f,-34.96f,0f);
    }
    
    public void LaraGoTest()
    { 
        StartCoroutine(LaraGoTestCorr());
    }
    IEnumerator LaraGoTestCorr()
    {
        Vector3 start = transform.position;
        Vector3 target = new Vector3(1375.16f,4.73f,1558.22f);
        Quaternion startRot = Quaternion.Euler(0f, 45f, 0f);
        Quaternion targetRot = Quaternion.Euler(0f, 48.283f, 0f);

        yield return new WaitForSeconds(15f);
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
        GetComponent<Animator>().SetBool("walk", true);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.04f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        startRot = Quaternion.Euler(0f, 48.283f, 0f);
        targetRot = Quaternion.Euler(0f, 135f, 0f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1.6f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
        start = transform.position;
        target = new Vector3(1383.04f,4.73f,1550.33f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.13f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        startRot = Quaternion.Euler(0f, 135f, 0f);
        targetRot = Quaternion.Euler(0f, 98.124f, 0f);
        start = transform.position;
        target = new Vector3(1388.42f,4.73f,1549.55f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.3f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t*3f);
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        GetComponent<Animator>().SetBool("walk", false);
        startRot = Quaternion.Euler(0f, 98.124f, 0f);
        targetRot = Quaternion.Euler(0f, 45f, 0f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1.6f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
    }

    public void LaraInElevator()
    { 
        if (elevator) 
            StartCoroutine(LaraInElevatorCorr());
    }
    IEnumerator LaraInElevatorCorr()
    {
        Vector3 start = transform.position;
        Vector3 target = new Vector3(1345.83f,4.736f,1532.07f);
        Quaternion startRot = Quaternion.Euler(0f, -135f, 0f);
        Quaternion targetRot = Quaternion.Euler(0f, 45f, 0f);

        GetComponent<Animator>().SetBool("walk", true);
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.4f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }

        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            GetComponent<Animator>().SetBool("walk", false);
            yield return null;
        }
        elevator = false;
    }

    public void LaraFrontElevator()
    {
        StartCoroutine(LaraFrontElevatorCorr());
    }
    IEnumerator LaraFrontElevatorCorr()
    {
        Vector3 start = new Vector3(1341.33f,4.736f,1543.33f);
        Vector3 target = new Vector3(1346.45f,4.736f,1538.60f);
        Quaternion startRot = Quaternion.Euler(0f, -136.041f, 0f);
        Quaternion targetRot = Quaternion.Euler(0f, -223.034f, 0f);

        yield return new WaitForSeconds(3f);
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1.4f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
        GetComponent<Animator>().SetBool("walk", true);

        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.21f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }

        gameObject.transform.Find("Point Light").gameObject.GetComponent<Light>().enabled = true;
        gameObject.transform.Find("Point Light (1)").gameObject.GetComponent<Light>().enabled = true;
        gameObject.transform.Find("Point Light (2)").gameObject.GetComponent<Light>().enabled = true;

        startRot = Quaternion.Euler(0f, -223.034f, 0f);
        targetRot = Quaternion.Euler(0f, -190.767f, 0f);
        start = transform.position;
        target = new Vector3(1347.67f,4.736f,1533.99f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.3f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        GetComponent<Animator>().SetBool("walk", false);

        startRot = Quaternion.Euler(0f, -194.767f, 0f);
        targetRot = Quaternion.Euler(0f, -135f, 0f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1.4f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
    }

    public void LaraInEnviro()
    {
        StartCoroutine(LaraInEnviroCorr());
    }
    IEnumerator LaraInEnviroCorr()
    {
        Vector3 start = new Vector3(1348.07f,4.736f,1538.92f);
        Vector3 target = new Vector3(1341.33f,4.736f,1543.33f);
        Quaternion startRot = transform.rotation;
        Quaternion targetRot = Quaternion.Euler(0f, -60.206f, 0f);

        yield return new WaitForSeconds(4f);
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1.8f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
        GetComponent<Animator>().SetBool("walk", true);

        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.2f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        GetComponent<Animator>().SetBool("walk", false);

        gameObject.transform.Find("Point Light").gameObject.GetComponent<Light>().enabled = false;
        gameObject.transform.Find("Point Light (1)").gameObject.GetComponent<Light>().enabled = false;
        gameObject.transform.Find("Point Light (2)").gameObject.GetComponent<Light>().enabled = false;
        
        startRot = transform.rotation;
        targetRot = Quaternion.Euler(0f, -136.041f, 0f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1.4f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
    }

    public void LaraGoEnviro()
    {
        StartCoroutine(LaraGoEnviroCorr());
    }
    IEnumerator LaraGoEnviroCorr()
    {
        Vector3 start = transform.position;
        Vector3 target = new Vector3(1348.07f,4.736f,1538.92f);
        Quaternion startRot = transform.rotation;
        Quaternion targetRot = Quaternion.Euler(0f, -128.428f, 0f);

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
            t += Time.deltaTime * 0.04f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        GetComponent<Animator>().SetBool("walk", false);
        
        startRot = transform.rotation;
        targetRot = Quaternion.Euler(0f, -225.904f, 0f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 1.1f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
    }

    public void XRayCinematic()
    {
        StartCoroutine(StartCinematic());
    }
    IEnumerator StartCinematic()
    {
        float t = 0f;
        Vector3 start = new Vector3(1377.34f,4.736f, 1563.40f);
        Vector3 target = new Vector3(1376.13f,4.736f,1562.01f);
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
        yield return new WaitForSeconds(4f);
        GetComponent<Animator>().SetBool("walk", true);

        start = transform.position;
        target = new Vector3(1374.72f,4.736f,1560.25f);
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 0.9f;
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
        Vector3 target = new Vector3(1377.34f,4.736f, 1563.40f);
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
            t += Time.deltaTime * 0.4f;
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