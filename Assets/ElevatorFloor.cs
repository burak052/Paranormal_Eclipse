using UnityEngine;
using System.Collections;

public class ElevatorFloor : MonoBehaviour
{
    public Material floor1;
    public Material floor2;
    public Material floor3;
    public Material floor4;
    public Material floor1stay;
    public Material floor2stay;
    public Material floor3stay;
    public Material floor4stay;
    public float delay = 3f;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void floorcall()
    {
        StartCoroutine(ChangeWithDelay());
        
    }
    IEnumerator ChangeWithDelay()
    {
        rend.material = floor4;
        yield return new WaitForSeconds(delay);
        rend.material = floor3;
        yield return new WaitForSeconds(delay);
        rend.material = floor2;
        yield return new WaitForSeconds(delay);
        rend.material = floor1;
        yield return new WaitForSeconds(delay);
        rend.material = floor1stay;
    }
}