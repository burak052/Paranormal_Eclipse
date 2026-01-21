using UnityEngine;

public class ChangeFloor : MonoBehaviour
{
    public GameObject floor1;
    public GameObject floor2;
    public LaraMovement Lara;
    public PlayLabAmbiance labAmbiance;

    void Start()
    {
        if(floor1 != null && floor2 != null)
        {
            floor1.SetActive(true);
            floor2.SetActive(false);
        }
    }
    public void GoToFloor1()
    {
        floor1.SetActive(true);
        floor2.SetActive(false);
    }
    public void GoToFloor2()
    {
        if(floor2 != null && floor1 != null)
        {
            labAmbiance.PlayAmbiance();
            floor1.SetActive(false);
            floor2.SetActive(true);
        }
    }
    public void LaraInEl()
    {
        if(Lara != null)
            Lara.LaraInElevator();
    }
}

