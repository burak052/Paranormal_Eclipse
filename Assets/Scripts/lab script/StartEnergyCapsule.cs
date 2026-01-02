using UnityEngine;

public class StartEnergyCapsule : MonoBehaviour
{
    public int count = 0;
    Transform parent;
    Vector3 pos;
    Quaternion rot;

    void Start()
    {
        parent = transform.parent;
        pos = transform.localPosition;
        rot = transform.localRotation;
    }

    public int TryCapsule()
    {
        count++;

        if(count == 5)
            gameObject.SetActive(false);
        else
        {
            if(count % 2 == 1)
                transform.Find("Cylinder").gameObject.SetActive(false);
            else
            {
                transform.Find("Cylinder").gameObject.SetActive(true);
                transform.Find("Cylinder").Find("gem").gameObject.GetComponent<Animator>().SetBool("start",true);
            }
        }
        return count;
    }
    public void SetParent()
    {
        transform.SetParent(parent);
        transform.localPosition = pos;
        transform.localRotation = rot;
    }
}
