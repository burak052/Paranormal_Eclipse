using UnityEngine;

public class ChangeFloor : MonoBehaviour
{
    public GameObject floor1;
    public GameObject floor2;
    public LaraMovement Lara;
    public PlayLabAmbiance labAmbiance;

    void Start()
    {
        floor1.SetActive(true);
        floor2.SetActive(false);
    }
    public void GoToFloor1()
    {
        floor1.SetActive(true);
        floor2.SetActive(false);
    }
    public void GoToFloor2()
    {
        labAmbiance.PlayAmbiance();
        floor1.SetActive(false);
        floor2.SetActive(true);
    }
    public void LaraInEl()
    {
        Lara.LaraInElevator();
    }
}

