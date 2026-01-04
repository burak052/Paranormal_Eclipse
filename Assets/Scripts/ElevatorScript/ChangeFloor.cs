using UnityEngine;

public class ChangeFloor : MonoBehaviour
{
    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor3;
    public LaraMovement Lara;

    void Start()
    {
        floor1.SetActive(true);
        floor2.SetActive(false);
        floor3.SetActive(false);
    }
    public void GoToFloor1()
    {
        floor1.SetActive(true);
        floor2.SetActive(false);
        floor3.SetActive(false);
    }
    public void GoToFloor2()
    {
        floor1.SetActive(false);
        floor2.SetActive(true);
        floor3.SetActive(false);
    }
    public void GoToFloor3()
    {
        floor1.SetActive(false);
        floor2.SetActive(false);
        floor3.SetActive(true);
    }

    public void LaraInEl()
    {
        Lara.LaraInElevator();
    }
}

