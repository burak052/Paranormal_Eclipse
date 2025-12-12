using UnityEngine;

public class ChangeFloor : MonoBehaviour
{
    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor3;
    public GameObject floor4;

    void Start()
    {
        floor1.SetActive(true);
        floor2.SetActive(false);
        floor3.SetActive(false);
        floor4.SetActive(false);
    }
    public void GoToFloor1()
    {
        floor1.SetActive(true);
        floor2.SetActive(false);
        floor3.SetActive(false);
        floor4.SetActive(false);
    }
    public void GoToFloor2()
    {
        floor1.SetActive(false);
        floor2.SetActive(true);
        floor3.SetActive(false);
        floor4.SetActive(false);
    }
    public void GoToFloor3()
    {
        floor1.SetActive(false);
        floor2.SetActive(false);
        floor3.SetActive(true);
        floor4.SetActive(false);
    }
    public void GoToFloor4()
    {
        floor1.SetActive(false);
        floor2.SetActive(false);
        floor3.SetActive(false);
        floor4.SetActive(true);
    }
}

