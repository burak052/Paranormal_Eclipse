using UnityEngine;

public class LockedDoorLight : MonoBehaviour
{
    public Raycast ray;
    bool first = true;
    void Update()
    {
        if(ray.accident && first)
        {
            transform.Find("Light1").Find("green").gameObject.SetActive(true);
            transform.Find("Light1").Find("red").gameObject.SetActive(false);
            transform.Find("Light2").Find("green").gameObject.SetActive(true);
            transform.Find("Light2").Find("red").gameObject.SetActive(false);
            transform.Find("Door").gameObject.tag = "BoilerDoor";
            first = false;
        }
    }
}
